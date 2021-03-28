# SatistackDiffer

A command line tool to generate a document describing Satisfactory game's item stack changes.

Usage:

```
SatistackDiffer --old C:\path\to\old\Docs.json --new C:\path\to\new\Satistack\Docs.json --output C:\path\to\output\updated.md
```

The tool generates a [Markdown](https://daringfireball.net/projects/markdown/) file at the given output location.

The `Docs.json` file describing the game items can be located under the installation directory of the game under `<installation path>\Satisfactory\CommunityResources\Docs\Docs.json`.

### Example output
---

Example output created by diffing early access Update 3 against latest experimental Update 4 (created 27/03/2021):

```markdown
| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Game\FactoryGame\Resource\Parts\Cement\UI\IconDesc_Concrete_64.png) </br>Concrete | 100 | **500** |
| ![text](Game\FactoryGame\Resource\Parts\IronPlate\UI\IconDesc_IronPlates_64.png) </br>Iron Plate | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\IronRod\UI\IconDesc_IronRods_64.png) </br>Iron Rod | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\Cable\UI\IconDesc_Cables_64.png) </br>Cable | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\AluminumPlate\UI\IconDesc_AluminiumSheet_64.png) </br>Alclad Aluminum Sheet | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\Rubber\UI\IconDesc_Rubber_64.png) </br>Rubber | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\CopperSheet\UI\IconDesc_CopperSheet_64.png) </br>Copper Sheet | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\Plastic\UI\IconDesc_Plastic_64.png) </br>Plastic | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\SteelPipe\UI\IconDesc_SteelPipe_64.png) </br>Steel Pipe | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\SteelPlate\UI\IconDesc_SteelBeam_64.png) </br>Steel Beam | 100 | **200** |
| ![text](Game\FactoryGame\Resource\Parts\Battery\UI\IconDesc_Battery_64.png) </br>Battery | 100 | **200** |
```

Markdown preview:

---

| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Docs\img\concrete.png) </br>Concrete | 100 | **500** |
| ![text](Docs\img\ironplates.png) </br>Iron Plate | 100 | **200** |
| ![text](Docs\img\ironrods.png) </br>Iron Rod | 100 | **200** |
| ![text](Docs\img\cables.png) </br>Cable | 100 | **200** |
| ![text](Docs\img\aluminiumsheet.png) </br>Alclad Aluminum Sheet | 100 | **200** |
| ![text](Docs\img\rubber.png) </br>Rubber | 100 | **200** |
| ![text](Docs\img\coppersheet.png) </br>Copper Sheet | 100 | **200** |
| ![text](Docs\img\plastic.png) </br>Plastic | 100 | **200** |
| ![text](Docs\img\steelpipe.png) </br>Steel Pipe | 100 | **200** |
| ![text](Docs\img\steelbeam.png) </br>Steel Beam | 100 | **200** |
| ![text](Docs\img\battery.png) </br>Battery | 100 | **200** |

---

## Displaying the attached images

To have the proper item images show up in the resulting Markdown file, use the `umodel` tool (available to download [here](https://www.gildor.org/en/projects/umodel)), and extract the files to the same folder the markdown was saved to:

```
.\umodel.exe -path="<installation path>\Satisfactory\FactoryGame\Content\Paks" -out="C:\path\to\output" -png -export *_64.uasset -game=ue4.22
```

For the current Update 4, the game version is `ue4.25`:

```
.\umodel.exe -path="<installation path>\Satisfactory\FactoryGame\Content\Paks" -out="C:\path\to\output" -png -export *_64.uasset -game=ue4.25
```

For later updates, please check the proper Unreal Engine version and update the command line invocation accordingly.
