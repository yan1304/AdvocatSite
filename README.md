# AdvocatSite
Сайт, с поддержкой CRUD-статей, для нужд адвоката (пока не опубликован)


Front-end: HTML, CSS, bootstrap, TypeScript, jQuery.
Back-end: ASP.NET MVC 5, SQL Server 2014, EntityFramework 6 (CodeFirst), Ioc Ninject.
Авторизация с помощью ASP.NET Identity
За основу взята трёхуровневая архитектрура.

Данный сайт позволяет динамично изменять его содержание (статьи, видео, новости и уведомления), название, информацию о владельце.
Он создан на основе ASP NET MVC 5. 
Состоит из 3х контроллеров: 
1) Admin для администрирования и редактирования сайта. Также содержит функции,
отправляющие пользователю JSON-файлы с содержанием статей, которые он запрашивает AJAX-запросами. 
2) Home для обычных посетителей сайта 
3) Account для авторизации на сайте. Авторизация скрыта от обычных пользователей. Также содержит методы для редактирования
информации о владельце сайта.

