/* 
Описание таблиц
*/

-- Описание таблицы с постами
CREATE TABLE dbo.O_POSTS (
    id INT PRIMARY KEY IDENTITY (1,1),
    caption VARCHAR (400) NOT NULL ,
    content VARCHAR (max)
)

-- Описание таблицы с тэгами
CREATE TABLE dbo.O_TAGS (
    id INT PRIMARY KEY  IDENTITY (1,1),
    tag VARCHAR (50) NOT NULL 
)

-- Описание таблицы связей
CREATE TABLE dbo.L_POSTS_TAGS (
    Post_Id INT NOT NULL,
    Tag_Id INT NOT NULL,
    CONSTRAINT PK_L_POSTS_TAGS PRIMARY KEY CLUSTERED (Post_Id, Tag_Id)
)


---------------------------------------------------------------------------------------
/* Собственно сам запрос */
---------------------------------------------------------------------------------------

SELECT 
     posts.caption
    ,tags.tag
FROM
    dbo.O_POSTS as posts
    LEFT OUTER JOIN dbo.L_POSTS_TAGS as l
    ON posts.id = l.Post_Id
    LEFT OUTER JOIN dbo.O_TAGS as tags
    ON l.Tag_Id = tags.id
    