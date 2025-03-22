# Relentless SMS Windows
# Relentless-SMS-for-Windows

While I don't ever post, I do come here frequently. I built a Windows program that is a "cellular phone stress tester". When you post numbers, I find them here and perform my "stress tests" on those individual phone numbers.

This app is a comprehensive internal security testing tool that automates email and SMS-based stress tests to overload cellular phones. It scrapes thousands of Mailman signup pages and submits validated email addresses and phone numbers (email to SMS method) at scale. Additionally, it integrates Textbelt's API to send SMS messages from multiple random numbers and exploits email-to-SMS gateways to overload cellular devices. The app reminds users to enable VPN protection for anonymity.

The tool supports six primary attack methods:

Mass Submission – Submits test emails to thousands of Mailman lists simultaneously.
Targeted Overload – Overwhelms a specific provider or domain with submissions.
Randomized Injection – Uses varied sender details and submission patterns to evade detection.
Incremental Escalation – Starts with low-volume submissions and gradually increases intensity.
Email-to-SMS Gateway Attack – Converts email spam into SMS spam by sending emails to carrier gateways.
Mailbait.info Browser Automation – Uses an integrated browser to submit the target address to Mailbait.info with unlimited open tabs.

APIs Used:
Shodan, SerpAPI (Google Dorking), SecurityTrails, and ZoomEye – Find and validate Mailman signup pages.

Textbelt API – Sends SMS messages from multiple phone numbers. Costs money, but sometimes you need to just send a message. Or many.

Email & Phone Validator API – Ensures valid submission data.

The system logs all failures, retries submissions after cooldowns, and extracts deeper signup links beyond Mailman index pages. The app is ideal for stress-testing email and SMS spam defenses with high-volume, real-world attack simulations.

Anti-Crime Messaging System
The app includes an anti-crime psychological deterrent that delivers messages in English, Chinese, and Hindi, confronting criminals with existential despair, inescapable consequences, and their inevitable demise. These messages serve as a digital intervention, forcing individuals engaging in illicit activities to reflect on their actions, failures, and the futility of their existence.

Examples of Anti-Crime Messages:
English:
Your life is a tragedy, a story of wasted potential and lost opportunities.
You're a walking corpse, slowly decaying from the inside out.
Your soul is forever tainted by your criminal actions. Death is the only escape.

Chinese:
你的罪行已将你抛入深渊，无法回头，死亡的阴影在你身后肆虐，追随着你，等待着你走向它的怀抱。
你是一个腐烂的尸体，已经不再属于这个世界，每一步都在走向终结，连空气中都弥漫着死亡的味道。
你的灵魂如同死灰，已被无情的黑暗吞噬，永远失去了任何光明，等待着死神的召唤。
Hindi:

तुम्हारा जीवन एक त्रासदी है, व्यर्थ संभावनाओं और खोए हुए अवसरों की कहानी।
तुम एक जिंदा लाश हो, अंदर से धीरे-धीरे सड़ रहे हो।
तुम्हारी आत्मा हमेशा के लिए भ्रष्ट हो चुकी है, मौत ही एकमात्र मुक्ति है।

By integrating psychological deterrents, high-volume email/SMS spamming techniques, email-to-SMS gateway exploitation, and automated Mailbait.info attacks, this tool is the ultimate stress-testing platform for email and SMS spam defenses. You can send THOUSANDS of messages from different URL's and numbers. It's hard to block a moving target.
