# prueba
public TablaUC(DataTable dt) {
    InitializeComponent();         dataGridView1.DataSource = dt; }
cadena = "Data Source =server16; Initial Catalog =Northwind; Persist Security Info = True; User ID =am; Password = 666666";
ExamenVO examenVO = new ExamenVO(cadena);
OperacionesBLL operacionesBLL = new OperacionesBLL();
con = operacionesBLL.CrearConexion(examenVO);
consulta = "SELECT EmployeeID, SUM(Freight) as TOTAL FROM Northwind.dbo.Orders GROUP BY EmployeeID ORDER BY EmployeeID";
da = new SqlDataAdapter(consulta, con);
OperacionesBLL op2 = new OperacionesBLL();
dt = op2.RealizarConsulta(da);
tp = tlp1;
uctabla = new UCtabla(dt);
tp.Controls.Add(uctabla, 0, 1);
ucgrafica = new UCgrafica(dt);
tp.Controls.Add(ucgrafica, 1, 1);
-----------------------------------------------------
DAL
public SqlConnection CrearConexion(ExamenVO examenVO){   try  {
    con = new SqlConnection(examenVO.Cadena);
    con.Open();
    MessageBox.Show("CONEXIÓN REALIZADA");
    } catch {   MessageBox.Show("CONEXIÓN FALLIDA"); } return con; }
-------------------------------------------------------------
public DataTable RealizarConsulta(SqlDataAdapter da) {
    dt = new DataTable();       da.Fill(dt);         return dt;  }
------------------------------------------------------------
public UCgrafica(DataTable dt)  {
    InitializeComponent();
    chart1.DataBindTable(dt.DefaultView, "EmployeeID");  }
-------------------------------------------------------------   
