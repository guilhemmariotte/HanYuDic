# HanYuDic

Open source Chinese–French/English/German dictionnary using the open source databases CFDict, CC-CEDict and HanDeDict. Written in Visual Basic (VB.NET) and designed with Microsoft Visual Basic Express 2008. Available for Windows only.

v2.0 - 2012. Guilhem Mariotte

License
-------
This application is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).


Terms of use
------------
You are free to share, copy and redistribute the material in any medium or format; You are free to adapt, remix, transform, and build upon the material for any purpose, even commercially.
You must however comply with the following conditions:
- Attribution: You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.
- Share Alike: If you remix, transform, or build upon the material, you must distribute your contributions under the same license as the original.


Disclaimer
----------
In no event shall the author of this application be liable to any party for direct, indirect, special, incidental, or consequential damages, including lost profits, arising out of the use of this application, even if the author has been advised of the possibility of such damages.
The author specifically disclaims any warranties, including, but not limited to, the implied warranties of merchantability and fitness for a particular purpose. The application and accompanying documentation, if any, provided hereunder is provided “as is”. The author has no obligation to provide maintenance, support, updates, enhancements, or modifications.


Known issue while editing files from HanYuDic on Windows 10
-----------------------------------------------------------
When HanYuDic is installed in Program Files, several errors with the mention "access denied" occur every time a file from the "data" or "config" folders must be modified (saving parameters, XML conversion). This is due to the property rights of all the files contained in Program Files which makes it difficult to edit them. As a lot of users will probably use Windows 10, the setup program directly suggests you to put the HanYuDic folder outside Program Files.


Known issue while launching HanYuDic on Windows XP
--------------------------------------------------
If you try to run the program with Windows XP, the following error may occur:
"the program did not launch correctly (error 0x0000135)"
In that case download the Microsoft .NET Framework 3.5 Service Pack 1 and install
it on your computer. You may download it at the following address:
http://www.microsoft.com/fr-fr/download/details.aspx?id=21
If the problem persists, then try another version of the .NET Framework.
If the problem is still there, I am afraid I can't help you anymore.
