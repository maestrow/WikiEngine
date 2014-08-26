# Wiki движок

Wiki движок с возможностями блога и позволяющий работать с вложениями через файловую систему.
Требования: ОС: Windows, SQL Server 2012 Express Advanced.
Возможность работы с вложениями и текстами статей через файловую систему обеспечивается функцией [Filetable](http://msdn.microsoft.com/ru-ru/library/ff929144.aspx) СУБД SQL Server.

[Описание проекта](https://github.com/maestrow/MyInternet)

## Миграции

`PM> Get-Migrations` - получить список всех миграций
`PM> Add-Migration <Name>`
`PM> Update-Database -TargetMigration:"CategoryIdIsLong"`