# 🎁 GiftTracker 🎁

Welcome to the GiftTracker wiki!

## Business Requirement
Create a software that simplifies tracking birthdays and gift purchases. 

## Use Cases
- **UC1: A user shall record gift data for gift recipients.**
  - *[FR1.1 A user shall create a recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/3)*
  - *[FR1.2 A user shall record the name of the recipient in the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/4)*
  - *[FR1.3 A user shall record the birthdate of an recipient in the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/5)* 
  - *[FR1.4 A user shall record other important gifting dates (e.g., Christmas, Chanukah) in the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/6)*
  - *[FR1.5 A user shall record a list of gift ideas in the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/7)*
    - *[FR1.5.1 A user shall enter the name of a gift in the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/31)*
    - *[FR1.5.2 A user shall enter gift information (item, price, and optional pruchase URL) in the gift field of the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/32)*
  - *[FR1.6 A user shall select 'Create Record' operation mode to enter a new recipient.](https://github.com/erobinson-mlis/gift-tracker/issues/8)*
  - *[NFR1.1 The interface shall be intuitive and simple to use.](https://github.com/erobinson-mlis/gift-tracker/issues/9)*
  - *[NFR1.2 A trained user shall be able to create and save a new record in under 2 minutes.](https://github.com/erobinson-mlis/gift-tracker/issues/10)*
  - *[NFR1.3 The data file shall be saved to persistent memory within 2 seconds.](https://github.com/erobinson-mlis/gift-tracker/issues/11)* 
- **UC2: A user shall save recipient records to a persistent data file**
  - *[FR2.1 A user shall save new recipient records to the persistent data file upon creation.](https://github.com/erobinson-mlis/gift-tracker/issues/12)*
  - *[FR2.2 A user shall select 'Read Data' mode to view records.](https://github.com/erobinson-mlis/gift-tracker/issues/13)*
  - *[NFR2.1 Database should scale up to 1000 entries without significant impact to use.](https://github.com/erobinson-mlis/gift-tracker/issues/14)*
  - *[NFR2.2 The user should load the data file for viewing within 2 sec.](https://github.com/erobinson-mlis/gift-tracker/issues/15)*
- **UC3: A user shall read the database to examine recipient information.**
  - *[FR3.1 A user shall select 'Load Data' to read data from the persistent data file.](https://github.com/erobinson-mlis/gift-tracker/issues/16)*
  - *[FR3.2 A user shall select a recipient by name to view the recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/17)*
  - *[FR3.3 A user shall view a list of upcoming gifting dates.](https://github.com/erobinson-mlis/gift-tracker/issues/18)*
- **UC4: A user shall receive automated reminder announcements ahead of gifting dates.**
  - *[FR4.1 A user shall login to their personal account to manage their data.](https://github.com/erobinson-mlis/gift-tracker/issues/19)*
  - *[FR4.2 A user shall enter their account email to receive email reminders.](https://github.com/erobinson-mlis/gift-tracker/issues/20)*
  - *[FR4.3 A user shall enter their account phone number to receive SMS reminders.](https://github.com/erobinson-mlis/gift-tracker/issues/21)*
  - *[FR4.4 The system shall send the user an event reminder by email and SMS 2 weeks before important dates.](https://github.com/erobinson-mlis/gift-tracker/issues/22)*
  - *[FR4.5 Event reminders should be sent out daily at 10:00 hours.](https://github.com/erobinson-mlis/gift-tracker/issues/23)*
  - *[NFR4.1 Once account information is entered, reminders should be sent with minimal action from the user.](https://github.com/erobinson-mlis/gift-tracker/issues/24)* 
- **UC5: A user shall enter spending suggestions into recipient records.**
  - *[FR5.1 A user shall optionally enter a suggested gift cost (min/max) in a recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/25?reload=1)*
  - *[FR5.2 A user shall optionally enter a suggested amount (min/max) for specific occasions.](https://github.com/erobinson-mlis/gift-tracker/issues/26)*
- **UC6 Recipient records shall integrate with online calendar, such as Google Calendar.**
  - *[FR6.1 A user shall securely enter account credentials for a Google cloud account.](https://github.com/erobinson-mlis/gift-tracker/issues/27)*
  - *[FR6.2 The system shall synchronize persistent data with the user's Google Calendar account.](https://github.com/erobinson-mlis/gift-tracker/issues/28)*
  - *[FR6.3 The user account shall be synchronized upon the entry of a new recipient record.](https://github.com/erobinson-mlis/gift-tracker/issues/29)*
  - *[NFR6.3 A user with account credentials should be able to set up account synchronization within 10 minutes.](https://github.com/erobinson-mlis/gift-tracker/issues/30)*
