#  Relentless SMS Windows 2025 – Changelog

##  Starting Point: Version 032325-07
Baseline version with core Mailman scraping, concurrency handling, VPN enforcement, and GUI layout established.

---

##  032325-08 to 032825-39
- Full VPN detection logic overhaul
- Instant submission halt on VPN drop
- Live field flash alert logic
- Elapsed timer integration + visibility post-shutdown
- Added fallback IPWHOIS VPN detection
- GUI field lockout during VPN loss or detection failure
- Enhanced field visual syncing during alert states

---

##  032925-01 to 032925-25
### Mailman Submission Confirmation Revamp
- `txtConfirm` logging introduced for verified submissions
- `txtConfirmed` counter added
- Confidence scoring logic based on response analysis
- Added `confirmed_urls.txt` and `confirmed_html_log.txt` for persistent tracking
- Dual-logging system (txtOutgoingMessages + txtConfirm)
- ScrollToCaret behavior added to both RTBs
- Refined “ Confirmed” feedback system
- Tooltip support for various form fields
- Live confirmation verification and post-delivery audit trail

---

##  032925-26 to 032925-38
### UI / Behavior Cleanup + Visual Consistency
- GUI synchronization between success and confirmation outputs
- E-STOP shutdown delay override (10s delay for post-log activity to finish)
- Resolved logging collisions and false duplicates
- Tightened logic around VPN loss re-entry
- GUI flash on VPN reconnect (for OPSEC awareness)

---

##  032925-39 to 032925-47
### Human Simulation Mode Begins
- Added `cbHumanMode` (enabled by default)
- Randomized sending order across signup list
- Live throttle jitter (±15%)
- Scrollbar-less auto-scroll confirmed on all RTBs
- Tooltip enhancements for `cbHumanMode` and `cbBusinessHours`

---

##  032925-48 to 032925-55
### Spam Evasion Tactics & Realistic Load Modeling
- `cbBusinessHours` added (restricts activity 10PM–6AM)
- Cooldown after every 25 submissions (30s–60s random pause)
- `tbThrottle` and `tbConcurrent` read dynamically
- Human-mode-aware timing decisions
- Accurate `delay` and `submissionCount` variable scoping
- 100% compile-stable loop logic with hard-coded corrections
- Title bar standardized to:
  `Me.Text = $"Version 0XXX25-XX | SIM ENV: TIER 1 | OPSEC | FOUO | PCII"`

---

##  Current Stable Build: 032925-55
