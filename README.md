# 🎁 GiftTracker 🎁

Welcome to the GiftTracker wiki!

## Business Requirement
Create a software that simplifies tracking birthdays and gift purchases. 

## Use Cases
- **UC1: A user shall record gift data for gift recipients.**
  - *FR1.1 A user shall create a database record for tracking a gift recipient.*
  - *FR1.2 A user shall record the name of the recipient in the recipient record.*
  - *FR1.3 A user shall record the birthdate of an recipient in the recipient record.* 
  - *FR1.4 A user shall record other important gifting dates (e.g., Christmas, Chanukah) in the recipient record.*
  - *FR1.5 A user shall record a list of gift ideas in the recipient record.*
    - *FR1.5.1 A user shall enter the name of a gift in the recipient record.*
    - *FR1.5.2 A user shall enter gift information (item, price, and optional pruchase URL) in the gift field of the recipient record.*
  - *FR1.6 A user shall select 'Create Record' operation mode to enter a new recipient.*
  - *NFR1.1 The interface shall be intuitive and simple to use.*
  - *NFR1.2 A trained user shall be able to create and save a new record in under 2 minutes.*
  - *NFR1.3 The data file shall be saved to persistent memory within 2 seconds.* 
- **UC2: A user shall save recipient records to a persistent data file**
  - *FR2.1 A user shall save new recipient records to the persistent data file upon creation.*
  - *FR2.2 A user shall select 'Read Data' mode to view records.*
  - *NFR2.1 Database should scale up to 1000 entries without significant impact to use.*
  - *NFR2.2 The user should load the data file for viewing within 2 sec.*
- **UC3: A user shall read the database to examine recipient information.**
  - *FR3.1 A user shall select 'Load Data' to read data from the persistent data file.*
  - *FR3.2 A user shall select a recipient by name to view the recipient record.*
  - *FR3.3 A user shall view a list of upcoming gifting dates.*
- **UC4: A user shall receive automated reminder announcements ahead of gifting dates.**
  - *FR4.1 A user shall login to their personal account to manage their data.*
  - *FR4.2 A user shall enter their account email to receive email reminders.*
  - *FR4.3 A user shall enter their account phone number to receive SMS reminders.*
  - *FR4.4 The system shall send the user an event reminder by email and SMS 2 weeks before important dates.*
  - *FR4.5 Event reminders should run daily at 00:00 hours. 
  - *NFR4.1 Once account information is entered, reminders should be sent with minimal action from the user.* 
- **UC5: A user shall enter spending suggestions into recipient records.**
  - *FR5.1 A user shall optionally enter a suggested gift cost (min/max) in a recipient record.*
  - *FR5.2 A user shall optionally enter a suggested amount (min/max) for specific occasions.*
- **UC6 Recipient records shall integrate with online calendar, such as Google Calendar.**
  - *FR6.1 A user shall securely enter account credentials for a Google cloud account.*
  - *FR6.2 The system shall synchronize persistent data with the user's Google Calendar account.*
  - *FR6.3 The user account shall be synchronized upon the entry of a new recipient record. 
  - *NFR6.3 A user with account credentials should be able to set up account synchronization within 10 minutes.*
  
