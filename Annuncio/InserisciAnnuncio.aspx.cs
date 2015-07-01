using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;

namespace Swimmy.Account
{
    public partial class InserisciAnnuncio : System.Web.UI.Page
    {
        private string nome;
        private int idUtente;
        private DB.Annuncio dbAnnuncio = new DB.Annuncio();
        private string fromRootToPhotos = @"../../App_Data/Photos/";
        private string partialPath = @"http://www.swimmy.it/App_Data/";
        private List<string> listaFotoDaSalvare;



        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            idUtente = (int)(Session["idUtente"]);

            if (nome == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                if ((Session["listaFoto"]) == null)
                    listaFotoDaSalvare = new List<string>();
                else
                    listaFotoDaSalvare = (List<string>)(Session["listaFoto"]);
                //userLabel.Text = nome;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int idAnnuncio;
            idAnnuncio = dbAnnuncio.InserisciAnnuncio(idUtente, txtTitolo.Text, txtDescrizione.Text, regioneDDL.Text, provinciaDDL.Text, txtCitta.Text, txtIndirizzo.Text, txtTelefono.Text);
            Session["idAnnuncio"] = idAnnuncio;
            foreach (string s in listaFotoDaSalvare)
            {
                dbAnnuncio.InserisciFoto(0, idAnnuncio, s);
            }
            Response.BufferOutput = true;
            Response.Redirect("~/Annuncio/Annuncio.aspx", false);
        }

        protected void popolaProvinciaDDL(object sender, EventArgs e)
        {
            List<string> listaProvince = dbAnnuncio.GetProvinceDaRegione(regioneDDL.Text);
            provinciaDDL.Items.Insert(0, "--Inserisci la provincia--");
            provinciaDDL.DataSource = listaProvince;
            provinciaDDL.DataBind();

        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuUpload.HasFile)
            {
                try
                {
                    if ((fuUpload.PostedFile.ContentType == "image/jpeg") ||
                        (fuUpload.PostedFile.ContentType == "image/png") ||
                        (fuUpload.PostedFile.ContentType == "image/bmp") ||
                        (fuUpload.PostedFile.ContentType == "image/gif"))
                    {
                        if (Convert.ToInt64(fuUpload.PostedFile.ContentLength) < 5000000)//=5Mb
                        {
                            // string photoFolder = Path.Combine(fromRootToPhotos, idUtente.ToString());//Path.Combine(fromRootToPhotos, User.Identity.Name);

                            //if (!Directory.Exists(photoFolder))
                            //  Directory.CreateDirectory(photoFolder);

                            string extension = Path.GetExtension(fuUpload.FileName);
                            string uniqueFileName = Path.ChangeExtension(fuUpload.FileName, DateTime.Now.Ticks.ToString());

                            string serverPath = Server.MapPath("~/App_Data/") + uniqueFileName + extension;
                            fuUpload.SaveAs(serverPath);



                            string path;
                            path = "App_Data//" + uniqueFileName + extension;

                            listaFotoDaSalvare.Add(path);//Path.Combine(partialPath + idUtente.ToString(), uniqueFileName + extension));
                            (Session["listaFoto"]) = listaFotoDaSalvare;
                            DisplayUploadedPhotos();

                            lblStatus.Text = "<font color='Green'>" + fuUpload.FileName + " caricata correttamente</font>";
                        }
                        else
                            lblStatus.Text = "Dimensione massima: 5MB.";
                    }
                    else
                        lblStatus.Text = "Le foto devono essere jpeg, jpg, png, bmp, o gif.";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
                lblStatus.Text = "Nessuna foto selezionata.";
        }

        public void DisplayUploadedPhotos()
        {
            //string[] allPhotoFiles = Directory.GetFiles(folder);
            IList<string> allPhotoPaths = new List<string>();
            string fileName;

            //foreach (string f in allPhotoFiles)
            foreach (string f in listaFotoDaSalvare)
            {
                fileName = Path.GetFileName(f);
                //allPhotoPaths.Add("Photos/" + User.Identity.Name + "/" + fileName);
                allPhotoPaths.Add(Path.Combine(Server.MapPath("~/App_Data"), fileName));
            }

            rptrUserPhotos.DataSource = allPhotoPaths;
            rptrUserPhotos.DataBind();
        }

        protected void imgUserPhoto_Command(object sender, CommandEventArgs e)
        {
            StringBuilder script = new StringBuilder();

            script.Append("<script type='text/javascript'>");
            script.Append("var viewer = new PhotoViewer();");
            script.Append("viewer.setBorderWidth(0);");
            script.Append("viewer.disableToolbar();");
            script.Append("viewer.add('" + e.CommandArgument + "');");
            script.Append("viewer.show(0);");
            script.Append("</script>");

            ClientScript.RegisterStartupScript(GetType(), "viewer", script.ToString());
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // This method is longer.

            //foreach (RepeaterItem ri in rptrUserPhotos.Items)
            //{
            //    Control ric = ri as Control;

            //    foreach (Control c in ric.Controls)
            //    {
            //        if (c is CheckBox)
            //        {
            //            CheckBox cb = (CheckBox)c;

            //            if (cb.Checked)
            //            {
            //                string fromPhotosToExtension = cb.Attributes["special"];
            //                string fromRootToHome = @"D:\LAB\Vincent\Projects\Practice\Photo Uploader\Photo Uploader\";
            //                string fileToDelete = Path.Combine(fromRootToHome, fromPhotosToExtension);
            //                File.Delete(fileToDelete);
            //            }
            //        }
            //    }
            //}

            //DisplayUploadedPhotos(Path.Combine(fromRootToPhotos, User.Identity.Name));

            // This method is shorter and simpler.

            bool deletionOccurs = false;

            foreach (RepeaterItem ri in rptrUserPhotos.Items)
            {
                CheckBox cb = ri.FindControl("cbDelete") as CheckBox;

                if (cb.Checked)
                {
                    string fromPhotosToExtension = cb.Attributes["special"];
                    string fileName = Path.GetFileName(fromPhotosToExtension);
                    //string fromRootToHome = "..//..//App_Data//";
                    listaFotoDaSalvare.Remove(fromPhotosToExtension);
                    (Session["listaFoto"]) = listaFotoDaSalvare;
                    string fileToDelete = Server.MapPath("~/App_Data/") + fileName; //Path.Combine(fromRootToHome, fromPhotosToExtension.Replace(@"http://www.swimmy.it/SwimmyUpload/", ""));
                    File.Delete(fileToDelete);

                    lblStatus.Text = "<font color='Green'>Foto eliminata/e correttamente.</font>";
                    deletionOccurs = true;
                }
            }

            if (!deletionOccurs)
                lblStatus.Text = "Seleziona una foto per cancellarla.";

            //DisplayUploadedPhotos(Path.Combine(fromRootToPhotos, User.Identity.Name));
            DisplayUploadedPhotos();
        }
    }
}