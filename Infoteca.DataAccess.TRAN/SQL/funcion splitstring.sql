Use Infoteca
GO

CREATE FUNCTION splitstring ( @stringToSplit VARCHAR(MAX) )
RETURNS
@returnList TABLE ([tag] [nvarchar] (500))
AS
BEGIN

 DECLARE @tag NVARCHAR(255)
 DECLARE @pos INT

 WHILE CHARINDEX(',', @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(',', @stringToSplit)  
  SELECT @tag = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @tag

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END

 INSERT INTO @returnList
 SELECT @stringToSplit

 RETURN
END