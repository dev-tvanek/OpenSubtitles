Titulková knihovna pro C#
Tato knihovna je určena pro vývojáře pracující s titulky ve videích nebo multimédiích v jazyce C#. Umožňuje snadné načítání, detekci, parsování a zobrazování titulků v různých formátech.

Funkce
Detekce Formátu Titulků: Automaticky identifikuje formát titulků na základě přípony souboru, podporuje formáty jako SRT (SubRip Text), SSA (SubStation Alpha), ASS (Advanced SubStation Alpha) a VTT (Web Video Text Tracks).

Detekce Kódování: Rozpoznává kódování souborů s titulky, podporuje různá Unicode kódování, včetně ASCII.

Parsování Titulků: Čte a analyzuje obsah titulkových souborů, rozděluje je na jednotlivé bloky s časovými kódy a textem.

Zobrazování Titulků: Poskytuje funkce pro výpis titulků, včetně jejich identifikátorů, časových razítek a textu.

Robustní Zpracování: Efektivně zpracovává různé formáty a kódování titulků, zajišťuje odolnost vůči chybám v souborech.

Rozšiřitelnost: Navrženo s možností snadného rozšíření pro podporu dalších formátů titulků.

Použití
Příklady použití knihovny jsou uvedeny v dokumentaci. Uživatelé mohou snadno načíst titulky, identifikovat jejich formát a kódování, parsovat a zobrazovat jejich obsah.

csharp
Copy code
SubtitleFileLoader loader = new SubtitleFileLoader("cesta/k/souboru.srt");
loader.DisplaySubtitles();
