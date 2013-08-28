using System;

namespace Aspose.Cloud.Pdf
{
    /// <summary>
    /// Represents Signature to sign PDF document
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// Gets or sets the signature path.
        /// </summary>
        /// <value>
        /// The signature path.
        /// </value>
        public string SignaturePath { get; set; }

        /// <summary>
        /// Gets or sets the type of the signature.
        /// </summary>
        /// <value>
        /// The type of the signature.
        /// </value>
        public SignatureType SignatureType { get; set; }
        /// <summary>
        /// Gets or sets the signature password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Sets or gets a graphic appearance for the signature. Property value represents an image file name.
        /// </summary>
        public string Appearance { get; set; }

        /// <summary>
        /// Gets or sets the reason of the signature.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the contact of the signature.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets the location of the signature.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Signature"/> is visible. Supports only when signing particular page.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the visible rectangle of the signature. Supports only when signing particular page.
        /// </summary>
        /// <value>
        /// The rectangle.
        /// </value>
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// Gets or sets the name of the signature field. Supports only when signing document with particular form field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FormFieldName { get; set; }


        /// <summary>
        /// Gets or sets the name of the person or authority signing the document..
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets the time of signing.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTimeSignature Date { get; set; }

        public Signature()
        {
            SignaturePath = "";
            SignatureType = SignatureType.PKCS1;
            Password = "";
            Appearance = "";
            Reason = "";
            Contact = "";
            Location = "";
            Visible = true;
            Rectangle = new Rectangle();
            FormFieldName = "";
            Authority = "";
            Date = new DateTimeSignature();
        }
        public Signature(string signaturePath,
         SignatureType signatureType,
         string password,
         string appearance,
         string reason,
         string contact,
         string location,
         bool visible,
         Rectangle rectangle,
         string formFieldName,
         string authority,
         DateTimeSignature date
             )
        {
            SignaturePath = signaturePath;
            SignatureType = signatureType;
            Password = password;
            Appearance = appearance;
            Reason = reason;
            Contact = contact;
            Location = location;
            Visible = visible;
            Rectangle = rectangle;
            FormFieldName = formFieldName;
            Authority = authority;
            Date = date;
        }
    }
}
