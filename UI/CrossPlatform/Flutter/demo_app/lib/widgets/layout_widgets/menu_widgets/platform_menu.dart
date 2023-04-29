//! PlatformMenu
import 'package:flutter/material.dart';

class PlatformMenuWidget extends StatelessWidget {
  const PlatformMenuWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return PlatformMenuBar(
      menus: <PlatformMenuItem>[
        PlatformMenu(
          label: 'Platform Menu',
          menus: <PlatformMenuItem>[
            PlatformMenuItemGroup(
              members: [
                PlatformMenuItem(
                  label: 'About',
                  onSelected: () {},
                ),
              ],
            ),
            PlatformMenuItemGroup(
              members: [
                PlatformMenu(
                  label: 'Messages',
                  menus: <PlatformMenuItem>[
                    PlatformMenuItem(
                      onSelected: () {},
                      shortcut: const CharacterActivator('F'),
                      label: 'Learn more',
                    ),
                  ],
                ),
              ],
            ),
            if (PlatformProvidedMenuItem.hasMenu(
                PlatformProvidedMenuItemType.quit))
              const PlatformProvidedMenuItem(
                  type: PlatformProvidedMenuItemType.quit),
          ],
        ),
      ],
      child: const Center(
        child: Text(
          'Flutter Mapp',
        ),
      ),
    );
  }
}
