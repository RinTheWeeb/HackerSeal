# HackerSeal

This plugin will kick (or ban depending on config) all new and freshly made steam accounts.

Suggestions are welcome in the Issues tab!

## Config Additions
Type Info:
- Boolean: True or False value
- String: A string of characters

## If you do not intend to change the default values, there's no need to include any of these in your config
### General Settings
Config Option | Value Type | Default Value | Description
--- | :---: | :---: | ---
hs_enabled | Boolean | True | `Enable / Disable` HackerSeal from loading on server start
hs_noban | Boolean | True | `Enable/Disable` HackerSeal will kick Limited Steam Accounts and Steam Accounts who didn't setup a profile from your server. Disable to ban them for 50 years instead. This will IP-Ban them if you enabled IP Banning this in your config.
hs_banmessage | String | New Steam accounts are not allowed on this server. You have been permanently banned. | Message to display when the player gets banned for having a Limited/No Profile steam account.
hs_kickmessage | String | New Steam accounts are not allowed on this server. | Message to display when the player gets kicked for having a Limited/No Profile steam account.

## DISCLAIMER

There are few people that have a limited steam account that play SCP:SL but are legit players. 
Use this at your own discretion.
