## План

- Простое CRUD-приложение
- Подключить FILETABLE
- Подключить полнотекстовый поиск
- Переделать все на шаблон AspNetBoilerplate
  - Twitter Bootstrap (Красивый клиент)
  - Переделать сервисы на abp.services
  - Локализация
  - Script Bundles
 

## 25.07.2014

- При заходе по адресу "http://localhost/WikiEngine" все относительные ajax вызовы идут к localhost, соответственно ни один js-файл вообще не загружается. 
Сайт корректно работает только при изначальном обращении к "http://localhost/WikiEngine" (в конце адреса - обязательный слэш).
  - Пытаюсь решить проблему принудительным добавлением слэша в конец адреса.
  - Ответа не нешел, оставил как есть
- Наткнулся на проблему http://stackoverflow.com/questions/19528206/bundle-includedirectory-in-mvc5-outputing-wrong-paths
http://aspnetoptimization.codeplex.com/workitem/105
Это заняло около часа, чтобы найти этот баг в инете
