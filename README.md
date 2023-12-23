# HC_Plugins
A collection of useful BepInEx plugins for 'HoneyCome' (global ver.) / 'HoneyCome come come party' (Steam ver.). Most plugins work both in the stock game and in the Dolce expansion, but the unmodified Steam version might have some issues.

## How to use
1. Install the latest nightly build of BepInEx6 (at least 6.0.0-be.680).
2. Download the plugin you want from the Releases tab.
3. Extract the release into the game root directory, where the BepInEx folder is.

To be able to change settings in-game by pressing F1, you have to install HC_BepisPlugins and BepInEx.ConfigurationManager.IL2CPP.

## Plugin descriptions
Short descriptions of what the plugins do and some additional notes if necessary.

### HC_HideLanguageSelector and HC_Studio_HideLanguageSelector
Hide the Language menu item from the title screen.

This is mainly useful for modpacks that include a custom launcher that overrides the language settings (otherwise the game might be set to Japanese but AutoTranslator set to English, which would machine translate the entire game).

### HC_Studio_TitleSkip
Automatically load into studio mode after starting DigitalCraft.

You can still go to the title screen by clicking `System > Back to Title` in the top left menu.
Can be turned off in plugin config.

## Contributing
You can open and compile the souce code with VS2022, simply clone the repository, open the .sln, and hit build. Required nuget packages should be automatically downloaded. PRs are very welcome.

Modder chat is mainly on the Koikatsu discord server.
