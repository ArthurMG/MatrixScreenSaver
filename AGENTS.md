This project is a Windows Screensaver implemented with Windows Forms and GDI+.
The application supports standard Windows screensaver modes:

/s — run screensaver
/c — open configuration dialog
/p <HWND> — preview mode inside Windows screensaver settings

Target framework:
.NET Framework 4.8
Windows Forms
GDI+

Development Goals
Primary goals:
Maintain compatibility with existing installations.
Keep code easy to understand and maintain.
Avoid introducing unnecessary dependencies.

Architecture
Entry point:
	Program.cs - supported arguments /s, /c, /p

Main components:
MainWindow — screensaver window
SettingsForm - form for chaning user settings
Glyph — represents a symbol that gets draw
GlyphProvider — creates glyphes and stores glyphe cache
Column — represents a group of glyphes that are rendered in vertical way
Settings — screensaver global settings
LocalizedStrings - stores strings for locatlization

Coding Rules
General
Prefer small focused classes.
Prefer composition over inheritance.
Avoid static mutable state.
Do not introduce service locators.
Do not introduce global singletons unless already used.

Naming
Use descriptive names.
Good:
ParticleRenderer
ScreenBounds
RenderFrame

Bad:
Utils2
ManagerX
DataHelper

Agent Workflow
Before implementing a change:
Read README.md.
Read docs/architecture.md.
Search for existing implementations before creating new code.
Prefer extending existing systems over creating parallel systems.

When making significant changes:
Explain reasoning.
List affected files.
Mention possible risks.

Definition of Done

A task is complete only if:
Project builds successfully.
Existing behavior is preserved.
New code follows project conventions.
No obvious resource leaks are introduced.