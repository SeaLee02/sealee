using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sealee.Util
{
    public class NopiHelper
    {
        #region DataTable与Excel的转换
        /// <summary>
        /// excel导入成DataTable
        /// </summary>
        /// <param name="ExcelFileStream">文件流</param>
        /// <param name="SheetIndex">开始的sheet</param>
        /// <param name="HeaderRowIndex">从第行开始读取</param>
        /// <param name="fileExt">文件名，带.</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExcelToTable(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex, string fileExt)
        {
            DataTable dt = new DataTable();
            IWorkbook workbook;
            //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook(ExcelFileStream);
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook(ExcelFileStream);
            }
            else
            {
                workbook = null;
            }
            if (workbook == null)
            {
                return null;
            }
            ISheet sheet = workbook.GetSheetAt(SheetIndex);

            //表头  
            IRow header = sheet.GetRow(HeaderRowIndex);
            List<int> columns = new List<int>();
            //填充列明
            for (int i = 0; i < header.LastCellNum; i++)
            {
                object obj = GetValueType(header.GetCell(i));
                if (obj == null || obj.ToString() == string.Empty)
                {
                    dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                }
                else
                {
                    dt.Columns.Add(new DataColumn(obj.ToString()));
                }

                columns.Add(i);
            }
            //数据  
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                DataRow dr = dt.NewRow();
                bool hasValue = false;
                foreach (int j in columns)
                {
                    dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                    if (dr[j] != null && dr[j].ToString() != string.Empty)
                    {
                        hasValue = true;
                    }
                }
                if (hasValue)
                {
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// DataTable转Excel保存在服务器
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static void TableToExcel(DataTable dt, string file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }
            if (workbook == null)
            {
                return;
            }
            //添加页
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            byte[] buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }


        /// <summary>
        /// DataTable转Excel转流
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">.xls,.xlsx</param>
        public static Stream StreamFromDataTable(DataTable dt, string fileExt)
        {
            //转为字节数组  
            MemoryStream ms = new MemoryStream();
            IWorkbook workbook = new XSSFWorkbook();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }
            if (workbook == null)
            {
                return null;
            }
            //添加页
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            workbook.Write(ms);
            //XSSFWorkbook 直接Write得不到数据，我们需要ToArray赋给新的内存流
            MemoryStream stream = new MemoryStream(ms.ToArray());
            return stream;
        }


        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }

            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }
        #endregion

        #region 类型映射

        /// <summary>
        /// DataTable转强类型
        /// </summary>
        /// <typeparam name="T">需要转换的类型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns>返回List<T></returns>
        public static List<T> Mapper<T>(DataTable dt)
        {
            List<T> result = new List<T>();
            List<string> ColumnNameList = new List<string>();
            foreach (DataColumn item in dt.Columns)
            {
                ColumnNameList.Add(item.ColumnName);
            }
            foreach (DataRow item in dt.Rows)
            {
                T d = Activator.CreateInstance<T>();
                Type pp = typeof(T);
                PropertyInfo[] ppList = pp.GetProperties();
                foreach (PropertyInfo pro in pp.GetProperties())
                {
                    if (ColumnNameList.Contains(pro.Name) && item[pro.Name] != null && item[pro.Name] != DBNull.Value)
                    {
                        Type type = pro.PropertyType;
                        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            type = type.GetGenericArguments()[0];
                        }
                        object value = Convert.ChangeType(item[pro.Name], type);
                        pro.SetValue(d, value, null);
                    }
                }
                result.Add(d);
            }
            return result;
        }

        /// <summary>
        /// 获取模板
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataTable Mapper<T>()
        {
            DataTable dt = new DataTable();
            Type types = typeof(T);
            foreach (PropertyInfo sp in types.GetProperties())//获得类型的属性字段  
            {
                if (sp.Name.ToLower() != "id")
                {
                    dt.Columns.Add(sp.Name);
                }
            }
            return dt;
        }

        #endregion


    }
}
