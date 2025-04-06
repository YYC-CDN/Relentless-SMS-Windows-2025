' 03/30/2025 - Mailman3.vb | Version 033025-03
' 03/30/2025 - Mailman3.vb | Version 033025-02
' Fixed function parameter type for Mailman3_DiscoveryAsync to List(Of String).
' =======================================================================================
Imports System.Net.Http
Imports HtmlAgilityPack
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Mailman3

    Public Async Function Mailman3_DiscoveryAsync(urlList As List(Of String), logAction As Action(Of String)) As Task
        Dim client As New HttpClient()
        Dim discoveredCount As Integer = 0
        Dim signupFile As String = "C:\RelentlessSMS\Mailman\signup_urls.txt"
        Dim failedLog As String = "C:\RelentlessSMS\Mailman\signup_mm3_failed.txt"

        If Not File.Exists(signupFile) Then IO.File.Create(signupFile).Dispose()
        Dim confirmedSet As New HashSet(Of String)(File.ReadAllLines(signupFile))

        For Each baseUrl In urlList
            Try
                If String.IsNullOrWhiteSpace(baseUrl) Then Continue For

                Dim candidates As New List(Of String) From {
                    baseUrl.TrimEnd("/") & "/archives/list/",
                    baseUrl.TrimEnd("/") & "/postorius/lists/",
                    baseUrl.TrimEnd("/") & "/accounts/signup/"
                }

                For Each candidate In candidates
                    Dim response As HttpResponseMessage = Await client.GetAsync(candidate)
                    If Not response.IsSuccessStatusCode Then Continue For

                    Dim html As String = Await response.Content.ReadAsStringAsync()
                    Dim htmlDoc As New HtmlDocument()
                    htmlDoc.LoadHtml(html)

                    Dim forms = htmlDoc.DocumentNode.SelectNodes("//form")
                    If forms Is Nothing Then Continue For

                    For Each form In forms
                        Dim formText = form.InnerHtml.ToLower()
                        Dim containsCSRF = formText.Contains("csrfmiddlewaretoken")
                        Dim hasEmailField = formText.Contains("name=""email""") OrElse formText.Contains("type=""email""")

                        If containsCSRF AndAlso hasEmailField Then
                            If Not confirmedSet.Contains(candidate) Then
                                File.AppendAllText(signupFile, candidate & Environment.NewLine)
                                confirmedSet.Add(candidate)
                                logAction($"✅ MM3 Found: {candidate}")
                                discoveredCount += 1
                            End If
                            Exit For
                        End If
                    Next
                Next

            Catch ex As Exception
                File.AppendAllText(failedLog, $"{baseUrl} - {ex.Message}{Environment.NewLine}")
                logAction($"❌ Error checking {baseUrl}: {ex.Message}")
            End Try
        Next

        logAction($"✅ MM3 Discovery Complete: {discoveredCount} new URLs added.")
    End Function

End Class