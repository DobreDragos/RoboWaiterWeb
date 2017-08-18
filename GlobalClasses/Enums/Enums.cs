using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Enums
{
    public enum VerifyVersionExceptions
    {
        Unknown = 0,
        HigherAppVersion = 1,
        HigherDbStep = 2,
        LocalDBStepNotExists = 3,
        VersionDoesNotExistInDb = 4,
        MustUpdate = 5,
        InvalidDbStep = 6
    }

    public enum VerifyLicenseExceptions
    {
        NoLicense = 0,
        InvalidLicense = 1,
        InvalidMacId = 2,
        LicenseExpired = 3
    }

    public enum SqlOperators
    {
        [Description("=")]
        equals = 0,
        [Description(">")]
        greater,
        [Description(">=")]
        greaterOrEqual,
        [Description("<")]
        lessThan,
        [Description("<=")]
        lessOrEqual,
        [Description(" LIKE ")]
        startsWidth,
        [Description(" LIKE ")]
        endsWidth,
        [Description(" LIKE ")]
        contains,
        [Description(" LIKE ")]
        equalsInsensitive,
        [Description(" <> ")]
        differs
    }

    public enum ProductStatus
    {
        /// <summary>
        /// Not selected
        /// </summary>
        None = -1,
        /// <summary>
        /// "Unblocked"
        /// </summary>
        Active = 0,
        /// <summary>
        /// Can not be purchased. "Blocat la achizitie"
        /// </summary>
        BlockedBuy,
        /// <summary>
        /// Can not be sold. "Blocare la vanzare"
        /// </summary>
        BlockedSale,
        /// <summary>
        /// Can not be sold or bought. "Blocat la achizitie si la vanzare"
        /// </summary>
        BlockedSaleBuy,
        /// <summary>
        /// Will not appear when searching products. Eg. Discontinued product
        /// </summary>
        Unused
    }
    public enum SqlLogicOperators
    {
        [Description("AND")]
        and ,
        [Description("OR")]
        or,
    }
    /// <summary>
    /// The states of the MainView
    /// ADD_PRODUCTS = adding products to the current receipt
    /// ADD_MOPS = add methods of payment to the current receipt
    /// </summary>
    public enum MainViewStates
    {
        Receipt = 0,
        SearchProducts = 1,
        Payment = 2,
        PrintingOldReceipts = 3
    }
    /// <summary>
    /// These are used to set the MessagePos box button types
    /// </summary>
    public enum MsgBoxType
    {
        OK = 0,
        YESNO = 1,
        YESNOCANCEL = 2,
        CUSTOM = 3,
        NONE
    }
    /// <summary>
    /// These are used to set what values the MessagePos box buttons will return
    /// </summary>
    public enum MsgBoxButtonReturnValue
    {
        Ok = 0,
        Yes = 1,
        No = 2,
        Cancel = 3
    }
    /// <summary>
    /// These are used to set the icon of the MessagePos box
    /// </summary>
    public enum MsgBoxIcon
    {
        NONE = 0,
        WARNING = 1,
        QUESTION = 2,
        ERROR = 3
    }
    /// <summary>
    /// What type of input box to create
    /// </summary>
    public enum InputBoxType
    {
        /// <summary>
        /// To add a discount or increase to a product's price
        /// </summary>
        PRICE_CHANGE = 0,
        /// <summary>
        /// To set the sale price of a product. Can also be used to get a decimal value.
        /// </summary>
        SET_PRICE = 1,
        /// <summary>
        /// To set the number of something ( meal tickets or vouchers )
        /// </summary>
        INPUT_NUMBER = 2,
        /// <summary>
        /// To set the value of something ( meal tickets or vouchers )
        /// </summary>
        INPUT_VALUE = 3
    }

    public enum FormStatus
    {
        /// <summary>
        /// Default state
        /// </summary>
        Normal = 0,
        /// <summary>
        /// New information is added to the form
        /// </summary>
        Add,
        /// <summary>
        /// An existing object/table is modified
        /// </summary>
        Modify
    }

    public enum ProductType
    {
        Normal = 0,
        Service = 2
    }
    /// <summary>
    /// Used to determine if product or Unit of measurement can be weighted.
    /// </summary>
    public enum Weightable
    {
        NotWeightable = 0,
        Weightable = 1
    }

    public enum UserRights
    {
        /// <summary>
        /// Acces everywhere
        /// </summary>
        Admin = 0,
        /// <summary>
        /// Access to modify products, see sales reports, units of measurement
        /// </summary>
        PowerUser,
        /// <summary>
        /// Access to sell only
        /// </summary>
        NormalUser
    }
    public enum UserStatus
    {
        Deactivated = 0,
        Active = 1
    }
    public enum ActivationStatus
    {
        Disabled = 0,
        Enabled = 1
    }

    /// <summary>
    /// Apply price change by value or percentage
    /// </summary>
    public enum PriceChangeType
    {
        Value = 0,
        Percentage = 1
    }
    /// <summary>
    /// Modify price. Discount or Increase
    /// </summary>
    public enum PriceChangeName
    {
        Discount = 0,
        Increase = 1
    }
    /// <summary>
    /// Description is the default row print length for that particular cash register
    /// </summary>
    public enum CashRegisterType
    {    
        [Description("25")]
        Alta = 0,
        [Description("20")]
        Success = 1
    }
    /// <summary>
    /// Folders regarding receipts. 
    /// </summary>
    public enum ReceiptDirType
    {
        /// <summary>
        /// Where the receipt is written for it to be printed
        /// </summary>
        Default = 0,
        /// <summary>
        /// Where information is found if receipt was printed with success
        /// </summary>
        Ok = 1,
        /// <summary>
        /// Where information is found if there was an error while printing the receipt
        /// </summary>
        Error = 2
    }

    /// <summary>
    /// A generic enum for Yes an No questions, comboboxes, etc.
    /// </summary>
    public enum GenericResponse
    {
        NO = 0,
        YES = 1
    }

    /// <summary>
    /// There are the default mop types and Custom mop types
    /// </summary>
    public enum MopType
    {
        Cash = 0,
        MealTicket,
        Credit,
        Card,
        Custom
    }

    public enum BillStatus
    {
        ReadyToPrint = 1,
        PrintFailed = 0
    }

    public enum WeightableProduct
    {
        NO = 0,
        YES = 1
    }

    public enum ReceiptPrintedStatus
    {
        Ok = 0,
        Timeout,
        Fail
    }

    public enum PrinterCommands
    {
        Print = 0,
        ReportX,
        ReportZ,
        Reprint
    }
    public enum ChangeQuantity
    {
        Add = 1,
        Subtract = -1
    }

    public enum ErrorCode
    {
        NO_ERROR_CODE = 0,
        CANT_SUB_QUANTITY = 10,
        CANT_MODIFY_QUANTITY_DECIMAL = 11,
        LOGIN_FAILED = 21,
        INSUFFICIENT_RIGHTS = 22
    }
    /// <summary>
    /// By which field to sort the products data grid view
    /// </summary>
    public enum dgvProductsFields
    {
        Code = 0,
        Description = 1,
        Price = 2,
        VatQuota = 3,
        Family = 4,
        BarCode = 5
    }
    /// <summary>
    /// Type of sorting. -1 = Descending / 1 = Ascending
    /// </summary>
    public enum SortType
    {
        // These values must not be changed from -1 or 1
        Descending = -1,
        Ascending = 1
    }

    public enum BarCodeStatus
    {
        InUse = 0,
        Deleted = 1
    }
}
