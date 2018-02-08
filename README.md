CM3D2.CategoryUnlocker
Sybaris Patcher that adds new menu categories and model slots.


!!!!!!!!!WARNING!!!!!!!!!!
In the unlikely even of this patcher becoming incompatible with the game or one wants to uninstall, ALL savefiles saved with this patcher active will be treated by the base game as invalid!
IF you wish to restore you save file to pre Unlocker state see this guide: https://github.com/Neerhom/CM3D2.CategoryUnlocker/wiki/Restoring-save-file


The patcher adds new menu categories and model slots, to extend maid customization.

List of added categories and associated models slots:

Head customization:

EYE2(folder_eye2, eye2) - none

MAKEUP1(makeup1) - none

MAKEUP2(makeup2) - none

The EYE2 (eye2, folder_eye2) is the same as normal eye categories(eye, folder_eye) and is intended for making maid with eye heterochromia. The initial release includes all eye menus from base game ported to it, and they affect right eye only. Mugen versions use EYE_R color.

MAKEUP1 and 2  are intended for makeup and facial tattoo mods. Release only includes del menus.

Body:
TATTOO2(acctatoo2) - none

TATTOO3(acctatoo3) - none

NAILS(nails) - nails

TOENAILS(toenails) - toenails

SKINTOON(skintoon) - none
    
TATTOO2 and 3, as the name suggest, are additional slots for tatoos. Release include tattoos ported from base game.
Nails and toenails, are well for nails and toenails mods. Release includes free color nails and toenails that can be colored with each available colorset.

SKINTOON is intended for skintoon mods(duh). Includes my bilinear toon and menu to restore default skintoon.

Clothing:
GENERAL1 (general1) - general1a,general1b

GENERAL2 (general2) - general2a,general2b

GENERAL3 (general3) - general3a,general3b

GENERAL4 (general4) - general4a,general4b

GENERAL5 (general5) - general5a,general5b

GENERAL6 (general6) - general6a,general6b

GENERAL7 (general7) - general7a,general7b
    
General purpose categories. Current release only contains del menus and modified phot_undressing_list.nei for photo mode.

Accessories:

EARS - ears

HORNS - horns

As the names suggest, these category are added to make ears and horns compatible with hats, without sacrificing any other category. The relesease includes ears and horns ported from base game.

And just because i can, the patcher also unlocks BODY category for Edit Screen. While this is somewhat redundant, because Edit Menu Utility Exist, but EMU require body menu to follow specific naming convention, and this does not.
Confirmed to not have any conflicts with EMU plugin. Mind you, unlike EMU this won't restore maid's last animation!

For more details regarding new categories and how to create mods for them see: https://github.com/Neerhom/CM3D2.CategoryUnlocker/wiki/Creating-mods-for-CategoryUnlocker

There appears to be a minor conflict with EditMenuUtility patcher, which can result in new categories not appearing in edit screen. The conflict can be solved by deleting EditMenuUtility.xml from UnityInjector/Config

Support by existing plugins:
none at the time of release
