--Create by "GK"


IF OBJECT_ID('fnSplit') > 0
BEGIN
	DROP FUNCTION dbo.fnSplit
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
* Creates a table out of a delimited list
* Usage: SELECT * FROM dbo.fnSplit('20,190,210',',')
*/
CREATE FUNCTION [dbo].[fnSplit]
(
      @List varchar(MAX), 
      @Del varchar(10) = ','
)
RETURNS @ListTable TABLE 
(
      ListID int IDENTITY , 
      Item varchar(300)
)
AS
BEGIN
      DECLARE @LenDel int
      DECLARE @Pos int
      DECLARE @Item nvarchar(200)
      
      --Get the length of the delimiter, use hack to get around LEN(' ') = 0 issue
      SET @LenDel = LEN(@Del + '|') - 1 

      SET @Pos = CHARINDEX(@Del, @List)
      WHILE @Pos > 0
      BEGIN
            --Get the item
            SET @Item = SUBSTRING(@List, 1, @Pos-1)
            --Add it to the table (if not empty string) 
            IF LEN(LTRIM(@Item)) > 0
                  INSERT @ListTable (Item) VALUES (LTRIM(@Item))
            --Remove the item from the list
            SET @List = STUFF(@List, 1, @Pos+@LenDel-1, '')
            --Get the position of the next delimiter
            SET @Pos = CHARINDEX(@Del, @List)         
      END
      
      --Add the last item to the table (if not empty string) 
      IF LEN(LTRIM(@List)) > 0
            INSERT @ListTable (Item) VALUES (LTRIM(@List))

      RETURN 
END
GO
