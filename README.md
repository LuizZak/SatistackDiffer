# SatistackDiffer

A command line tool to generate a document describing Satisfactory game's item stack changes.

Usage:

```
SatistackDiffer --old C:\path\to\old\Docs.json --new C:\path\to\new\Satistack\Docs.json --output C:\path\to\output\updated.md
```

The tool generates a [Markdown](https://daringfireball.net/projects/markdown/) file at the given output location.

The `Docs.json` file describing the game items can be located under the installation directory of the game under `<installation path>\Satisfactory\CommunityResources\Docs\Docs.json`.

### Images

To have the proper icons show up in the resulting Markdown file, use the `umodel` tool (available to download [here](https://www.gildor.org/en/projects/umodel)), and extract the files to the same folder the markdown was created with:

```
.\umodel.exe -path="<installation path>\Satisfactory\FactoryGame\Content\Paks" -out="C:\path\to\output" -png -export *_64.uasset -game=ue4.22
```

For the current Update 4, the game version is `ue4.25`:

```
.\umodel.exe -path="<installation path>\Satisfactory\FactoryGame\Content\Paks" -out="C:\path\to\output" -png -export *_64.uasset -game=ue4.25
```

For later updates, please check the proper Unreal Engine version and update the command line invocation accordingly.
