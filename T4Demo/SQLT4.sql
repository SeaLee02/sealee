--��ӱ������
--��ʽ���ң�execute sp_addextendedproperty 'MS_Description','�ֶα�ע��Ϣ','user','dbo','table','�ֶ������ı���','column','���ע�͵��ֶ���';

--��ӱ�����
EXECUTE sp_addextendedproperty 'C', '�γ̱�', 'user', 'dbo', 'table', 'Course',
    NULL, NULL;
    
--����ֶ�����
EXECUTE sp_addextendedproperty 'MS_Description', '�γ�ID', 'user', 'dbo',
    'table', 'Course', 'column', 'CourseId';

--��ѯ���Եı�����
SELECT  name
FROM    sysobjects
WHERE   xtype = 'u';

--��ѯ�������
SELECT  tbs.name ���� ,
        ds.value ����
FROM    sys.extended_properties ds
        LEFT JOIN sysobjects tbs ON ds.major_id = tbs.id
WHERE   ds.minor_id = 0
        AND tbs.name = 'Course';

--��ѯ���е������ֶ�
SELECT  name
FROM    syscolumns
WHERE   id = OBJECT_ID('Standard');
--��ѯָ�����е������ֶ������ֶ�����
SELECT  sc.name ,
        st.name ,
        sc.isnullable ,
        sc.length
FROM    syscolumns sc ,
        systypes st
WHERE   sc.xusertype = st.xusertype
        AND sc.id = OBJECT_ID('Course');



--��ȡ��Ľṹ  ������ӵ���ţ��������Ƿ�ӵ������������������������������������
SELECT  obj.name tablename ,
        schem.name schemname ,
        idx.rows ,
        CAST(CASE WHEN ( SELECT COUNT(1)
                         FROM   sys.indexes
                         WHERE  object_id = obj.object_id
                                AND is_primary_key = 1
                       ) >= 1 THEN 1
                  ELSE 0
             END AS BIT) HasPrimaryKey ,
        ( SELECT    ds.value
          FROM      sys.extended_properties ds
                    LEFT JOIN sysobjects tbs ON ds.major_id = tbs.id
          WHERE     ds.minor_id = 0
                    AND tbs.name = obj.name
        ) AS TableDesc ,
        t.*
FROM    sys.objects obj
        INNER JOIN dbo.sysindexes idx ON obj.object_id = idx.id
                                         AND idx.indid <= 1
        INNER JOIN sys.schemas schem ON obj.schema_id = schem.schema_id
        LEFT JOIN sys.extended_properties b ON obj.object_id = b.major_id
                                               AND b.minor_id = 0
        OUTER APPLY ( SELECT TOP 1
                                b.name AS TablePrimarkeyType ,
                                a.name AS TablePrimarkeyName
                      FROM      syscolumns a
                                INNER JOIN systypes b ON a.xtype = b.xtype
                      WHERE     id = OBJECT_ID(obj.name)
                                AND a.colid IN (
                                SELECT  ic.column_id
                                FROM    sys.indexes idx
                                        INNER JOIN sys.index_columns ic ON idx.index_id = ic.index_id
                                                              AND idx.object_id = ic.object_id
                                WHERE   idx.object_id = OBJECT_ID(obj.name)
                                        AND idx.is_primary_key = 1 )
                    ) t
WHERE   obj.type = 'U'
       -- AND obj.name LIKE 'My_%'
ORDER BY obj.name;