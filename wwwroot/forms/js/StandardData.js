const Gender = [
	 {id:1, name:"male", displayname: "Male" },
	 {id:2, name:"female", displayname: "Female" }
];
const TaxRegionNames = [
    { id: 1, name: "IntraState", displayname: "Intra State" },
    { id: 2, name: "InterState", displayname: "Inter State" },
    { id: 3, name: "Import", displayname: "Import" },
    { id: 4, name: "Export", displayname: "Export" }
];

const TaxRegistrationTypes = [
    { id: 1, name: "RegularRegistration", displayname: "Regular Registration" },
    { id: 2, name: "RegistrationUnderSEZ", displayname: "Registration Under SEZ" },
    { id: 3, name: "RegistrationUnderUnionTerritory", displayname: "Registration Under Union Territory" },
    { id: 4, name: "RegistrationUnderCompositionScheme", displayname: "Registration Under Composition Scheme" },
    { id: 5, name: "NotRegistered", displayname: "Not Registered" },
    { id: 6, name: "DeemedExport", displayname: "Deemed Export" },
    { id: 7, name: "Export", displayname: "Export" },
    { id: 8, name: "Import", displayname: "Import" }
];

const EDocTypes = [
    { id: 1, name: "", displayname: "Advance Adjustments(ATAD)" },
    { id: 2, name: "", displayname: "Business-to-Business Amendment (B2BA)" },
    { id: 3, name: "", displayname: "Business-to-Business(B2B)" },
    { id: 4, name: "", displayname: "Business-to-Consumer Large Invoices Amendment(B2CLA)" },
    { id: 5, name: "", displayname: "Business-to-Consumer Large Invoices(B2CL)" },
    { id: 6, name: "", displayname: "Business-to-Consumer Small Invoices(B2CS)" },
    { id: 7, name: "", displayname: "Business-to-Consumer(B2C)" },
    { id: 8, name: "", displayname: "Business-to-Employee(B2E)" },
    { id: 9, name: "", displayname: "Business-to-Government(B2G)" },
    { id: 10, name: "", displayname: "Business-to-Manager(B2M)" },
    { id: 11, name: "", displayname: "Consumer-to-Business(C2B)" },
    { id: 12, name: "", displayname: "Consumer-to-Consumer(C2C)" },
    { id: 13, name: "", displayname: "Credit/Debit Note for Unregistered(CDNUR)" },
    { id: 14, name: "", displayname: "Exports Amendment(EXPA)" },
    { id: 15, name: "", displayname: "Exports(EXP)" },
    { id: 16, name: "", displayname: "Government-to-Business(G2B)" },
    { id: 17, name: "", displayname: "Government-to-Citizen(G2C)" },
    { id: 18, name: "", displayname: "Government-to-Employee(G2E)" },
    { id: 19, name: "", displayname: "Government-to-Government(G2G)" },
    { id: 20, name: "", displayname: "Nil Rated/Exempted/Non GST(EXEMP)" },
    { id: 21, name: "", displayname: "Taxable liability on Advance(AT)" }
];

const SystemAddressType = [
    { id: 1, name: "Company", displayname: "Company" },
    { id: 2, name: "Billing", displayname: "Billing" },
    { id: 3, name: "Shipping", displayname: "Shipping" }
];
const TerritoryType = [
    { id: 1, displayname: "Sales", name: "Sales" },
    { id: 2, displayname: "Purchase", name: "Purchase" }
];
const ResourceType = [
    { id: 1, displayname: "Administrative", name: "Administrative" },
    { id: 2, displayname: "Finance", name: "Finance" },
    { id: 2, displayname: "Manufacturing", name: "Manufacturing" },
    { id: 2, displayname: "Marketing", name: "Marketing" },
    { id: 2, displayname: "Purchase", name: "Purchase" },
    { id: 2, displayname: "Quality", name: "Quality" },
    { id: 2, displayname: "Sales", name: "Sales" },
    { id: 2, displayname: "Servicing", name: "Servicing" }
];
const RecordStatus = {
    Active: "active",
    Inactive: "inactive",
    Converted: "converted",
    Deleted: "deleted",
    Archived: "archived"
};
const EnquiryFor = [
    { id: 1, name: "product" },
    { id: 2, name: "service" },
    { id: 3, name: "dealership" },
    { id: 4, name: "spare" },
    { id: 5, name: "other" }
];
const QuotationSource = [
    { id: 1, displayname: "Direct", name: "Direct" },
    { id: 2, displayname: "Enquiry", name: "Enquiry" },
    { id: 3, displayname: "Quotation", name: "Quotation" }
];
const FunctionalTypes = [
    { id: 1, name: "Finance", displayname: "Finance" },
    { id: 2, name: "Production", displayname: "Production" },
    { id: 3, name: "Purchase", displayname: "Purchase" },
    { id: 4, name: "Sales", displayname: "Sales" },
    { id: 5, name: "Stores", displayname: "Stores" },
    { id: 6, name: "HRD", displayname: "HRD" },
    { id: 7, name: "Admin", displayname: "Admin" }
];
const Responsibility = [
    { id: 1, name: "Company", displayname: "Company" },
    { id: 2, name: "Customer", displayname: "Customer" },
    { id: 3, name: "Department", displayname: "Department" },
    { id: 4, name: "Employee", displayname: "Employee" },
    { id: 5, name: "ThirdPartySupplier", displayname: "Third Party Supplier" },
    { id: 6, name: "ThirdPartyCustomer", displayname: "Third Party Customer" },
    { id: 7, name: "Other", displayname: "Other" }
];
const DiscountType = [
    { id: 1, name: "Percentage", displayname: "Percentage" },
    { id: 2, name: "Amount", displayname: "Amount" }
];
const PaymentMode = [
    { id: 1, name: "Cash", displayname: "Cash" },
    { id: 2, name: "Cheque", displayname: "Cheque" }
];
const PaymentStatus = [
    { id: 1, name: "Collected", displayname: "Collected" },
    { id: 2, name: "Expired", displayname: "Expired" },
    { id: 3, name: "Infuture", displayname: "In future" },
    { id: 4, name: "Required", displayname: "Required" },
    { id: 5, name: "Submitted", displayname: "Submitted" }
];
const BusinessPatnerType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Dealer", displayname: "Dealer" },
    { id: 3, name: "Salesagent", displayname: "Sales agent" },

];
const TaxRoundType = [
    { id: 1, name: "None", displayname: "None" },
    { id: 2, name: "Normal", displayname: "Normal" },
    { id: 3, name: "Ciel", displayname: "Ciel" },
    { id: 4, name: "FLoor", displayname: "FLoor" },
];

const TaxRoundToValue = [
    { id: 0, name: "0", displayname: "0" },
    { id: 1, name: "1", displayname: "1" },
    { id: 10, name: "10", displayname: "10" },
    { id: 100, name: "100", displayname: "100" },
    { id: 1000, name: "1000", displayname: "1000" }
];

const ExpressionType = [
    { id: 1, name: "Entry", displayname: "Entry" },
    { id: 2, name: "Formula", displayname: "Formula" },
    { id: 3, name: "TaxFormula", displayname: "Tax Formula" }
];
const AlertMessageType = [
    { id: 1, name: "success", displayname: "Success" },
    { id: 2, name: "error", displayname: "Error" },
    { id: 3, name: "warning", displayname: "Warning" }
];

const AreaNames = [
    { id: 1, name: "Sales", displayname: "Sales" },
    { id: 2, name: "Finance", displayname: "Finance" },
    { id: 3, name: "Inventory", displayname: "Inventory" }
];
const InvoiceSource = [
    { id: 1, name: "SalesOrder", displayname: "SalesOrder" },
    { id: 2, name: "PackingSlip", displayname: "PackingSlip" }
];
const InvoiceTypes = [
    { id: 1, name: "FullValueInvoice", displayname: "Full Value Invoice" },
    { id: 2, name: "ZeroValueInvoice", displayname: "Zero Value Invoice (Expense)" },
    { id: 3, name: "ZeroValueInvoiceTaxReceivable", displayname: "Zero Value Invoice (Tax Receivable)" },
    { id: 4, name: "FreeReplacementInvoice", displayname: "Free Replacement Invoice" }
];
const GSTInvoiceType = [
    { id: 1, name: "Regular", displayname: "Regular" },
    { id: 2, name: "DeemedExport", displayname: "Deemed Export" },
    { id: 3, name: "ExportwithPayment", displayname: "Export with Payment" },
    { id: 4, name: "ExportwithoutPayment", displayname: "Export without Payment" },
    { id: 5, name: "SEZSuppliesWithPayment", displayname: "SEZ Supplies With Payment" },
    { id: 6, name: "SEZSuppliesWithoutPayment", displayname: "SEZ Supplies Without Payment" }
];
const InvoiceMethodOfTransaction = [
    { id: 1, name: "RaiseInvoiceVoucher", displayname: "Raise Invoice Voucher" },
    { id: 2, name: "RaiseDebitNote", displayname: "Raise Debit Note" }
];
const AdditionalChargeSource = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Product", displayname: "Product" },
    { id: 3, name: "SalesQuotation", displayname: "Sales Quotation" },
    { id: 4, name: "SalesOrder", displayname: "Sales Order" },
    { id: 5, name: "SalesInvoice", displayname: "Sales Invoice" },
    { id: 6, name: "PurchaseQuotation", displayname: "Purchase Quotation" },
    { id: 7, name: "PurchaseOrder", displayname: "Purchase Order" },
    { id: 8, name: "PurchaseInvoice", displayname: "Purchase Invoice" },
    { id: 9, name: "Supplier", displayname: "Supplier" }
];
const DirectInwardSourceType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Supplier", displayname: "Supplier" },
    { id: 3, name: "Department", displayname: "Department" }
];
const InwardConditions = [
    { id: 1, name: "Good", displayname: "Good" },
    { id: 2, name: "Damaged", displayname: "Damaged" },
    { id: 3, name: "Repaired", displayname: "Repaired" },
    { id: 4, name: "Scrapped", displayname: "Scrapped" }
];
const InwardActionTypes = [
    { id: 1, name: "QCApplicable", displayname: "QC Applicable" },
    { id: 2, name: "DirectStockUpdation", displayname: "Direct Stock Updation" },
    { id: 3, name: "StockUpdationRequest", displayname: "Stock Updation Request" }
];
const InwardStockingTypes = [
    { id: 1, name: "None", displayname: "None" },
    { id: 2, name: "SerialNoWise", displayname: "Serial No. Wise" },
    { id: 3, name: "BatchNoWise", displayname: "Batch Wise" },
    { id: 4, name: "None", displayname: "None" },
    { id: 5, name: "SerialNoWise", displayname: "Serial No. Wise" },
    { id: 6, name: "BatchNoWise", displayname: "Batch Wise" }

];
const InwardStatus = [
    { id: 1, name: "Completed", displayname: "Completed" }
];
const InvoiceTypeList = [
    { id: 1, name: "FullValueInvoice", displayname: "Full Value Invoice" },
    { id: 2, name: "ZeroValueInvoiceExpense", displayname: "Zero Value Invoice (Expense)" },
    { id: 3, name: "ZeroValueInvoiceTaxReceivable", displayname: "Zero Value Invoice (Tax Receivable)" },
    { id: 4, name: "FreeReplacementInvoice", displayname: "Free Replacement Invoice" }
];
const InvoiceDocType = [
    { id: 1, name: "DirectInvoice", displayname: "Direct Invoice" },
    { id: 2, name: "InvoiceAgainstSalesOrder", displayname: "Invoice Against Sales Order" },
    { id: 3, name: "InvoiceAgainstPackingSlip", displayname: "Invoice Against Packing Slip" },
    { id: 4, name: "DirectProformaInvoice", displayname: "Direct Proforma Invoice" },
    { id: 5, name: "ProformaInvoiceAgainstSalesOrder", displayname: "Proforma Invoice (Order wise - Product wise)" },
    { id: 6, name: "ProformaInvoiceAgainstPackingSlip", displayname: "Proforma Invoice Against Packing Slip" }
];
const RateContract = [
    { id: 1, name: "Rate Contract", displayname: "Rate Contract" },
    { id: 2, name: "Approved Quoation", displayname: "Approved Quoation" },
    { id: 3, name: "Master PriceList for Sales/Purchase", displayname: "Master PriceList for Sales/Purchase" },
    { id: 4, name: "Last Order rate for item from same Party", displayname: "Last Order rate for item from same Party" },
    { id: 5, name: "Latest Order Rate", displayname: "Latest Order Rate" },
    { id: 6, name: "Company wise item rate", displayname: "Company wise item rate" },
    { id: 7, name: "Price Scheme Rate", displayname: "Price Scheme Rate" },
    { id: 8, name: "Bill Of material", displayname: "Bill Of material" },
    { id: 9, name: "Latest Receipt Rate", displayname: "Latest Receipt Rate" },
    { id: 10, name: "Master Price List - Trading", displayname: "Master Price List - Trading" },
    { id: 11, name: "Previous Bill of Material", displayname: "Previous Bill of Material" }

];

const DeducteeType = [
    { id: 1, name: "Company", displayname: "Company" },
    { id: 2, name: "NonCompany", displayname: "Non-Company" }
];
const PackingUnit = [
    { id: 1, name: "Actual", displayname: "Actual" },
    { id: 2, name: "Standard", displayname: "Standard" }
];
const SupplierProductStatus = [
    { id: 1, name: "Approved", displayname: "Approved" },
    { id: 2, name: "OnHold", displayname: "On Hold" },
    { id: 3, name: "Blocked", displayname: "Blocked" },
    { id: 4, name: "TemporarilyApproved", displayname: "Temporarily Approved" }
];
const PurchaseLeadTimeFormat = [
    { id: 1, name: "Days", displayname: "Days" },
    { id: 2, name: "Hours", displayname: "Hours" },
    { id: 3, name: "Months", displayname: "Months" },
    { id: 4, name: "Weeks", displayname: "Weeks" }
];
const BOMLeadTime = [
    { id: 1, name: "Days", displayname: "Days" },
    { id: 2, name: "Hours", displayname: "Hours" },
    { id: 3, name: "Minutes", displayname: "Minutes" }
];
const PackingUnitRoundingType = [
    { id: 1, name: "Lower", displayname: "Lower" },
    { id: 2, name: "Upeer", displayname: "Upper" },
    { id: 3, name: "NA", displayname: "N/A" }
];
const DocumentTypes = [
    { id: 1, name: "Document", displayname: "Document" },
    { id: 2, name: "Report", displayname: "Report" },
    { id: 3, name: "Gadget", displayname: "Gadget" }
];

//#region Quality Check Data
const QCInwardTypes = [
    { id: 1, name: "DirectInward", displayname: "Direct Inward" },
    { id: 2, name: "PurchaseOrder", displayname: "Purchase Order" },
    { id: 3, name: "SalesOrder", displayname: "Sales Order" },
    { id: 4, name: "SubContractingOrder", displayname: "Sub-Contracting Order" }
];
//#endregion
const AcceptType = [
    { id: 1, name: "Accept", displayname: "Accept" },
    { id: 2, name: "ConditionalAccept", displayname: "Conditional Accept" },
    { id: 3, name: "AcceptafterRework", displayname: "Accept after Rework" },
    { id: 4, name: "AcceptonDeviation", displayname: "Accept on Deviation" },
    { id: 5, name: "AcceptwithReworkandDeviation", displayname: "Accept with Rework and Deviation" }
]

const RejectType = [
    { id: 1, name: "DamagefromInternalDepartment", displayname: "Damage from Internal Department" },
    { id: 2, name: "DamagefromSupplier", displayname: "Damage from Supplier" },

]
const DocumentIDs = [
    { id: 2, name: "DirectInvoice", displayname: "Direct Invoice" },
    { id: 3, name: "EnquiryGenericSales", displayname: "Enquiry-Generic(Sales)" },
    { id: 6, name: "OrderGenericSales", displayname: "Order-Generic(Sales)" },
    { id: 7, name: "QuoationGenericSales", displayname: "Quoation-Generic(Sales)" },
    { id: 13, name: "OrderGenericPurchase", displayname: "Order-Generic(Purchase)" }
];
const ActionTypeFor = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Supplier", displayname: "Supplier" },
    { id: 3, name: "Document", displayname: "Document" },
    { id: 4, name: "Product", displayname: "Product" },
    { id: 5, name: "Department", displayname: "Department" },
    { id: 6, name: "ProductGroup", displayname: "ProductGroup" }

];

const SalesRateSettings = [

    { id: 1, name: "Direct Invoice", resource: "SDirectInvoice", rates: [6, 3, 10, 8, 4] },
    { id: 2, name: "Sales Enquiry", resource: "SEnquiry", rates: [8, 5, 6, 10, 1, 2, 3, 4] },
    { id: 3, name: "Invoice Against Issue", resource: "SInvoiceAgIS", rates: [6, 3, 10, 8, 4] },
    { id: 4, name: "Sales Order (open) ", resource: "SOOrder", rates: [1, 2, 3, 4, 5, 6, 8, 10] },
    { id: 5, name: "Sales Order", resource: "SOrder", rates: [1, 2, 3, 4, 5, 6, 8, 10] },
    { id: 6, name: "Sales Quotation", resource: "SQuotation", rates: [8, 5, 6, 10, 1, 2, 3, 4] },
    { id: 7, name: "Sales Order (Rate Contract)", resource: "SSOrderRate", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 8, name: "Stock Transfer Invoice", resource: "SStockRIN", rates: [6, 3, 10, 8, 4] }


];
const PurchaseRateSettings = [
    { id: 9, name: "Job Card Based PO", resource: "PurJobCardPO", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 10, name: "Purchase Order(Open)", resource: "PurOrdersOpen", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 11, name: "Purchase Order", resource: "PurOrders", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 12, name: "PRN Based PO", resource: "PurPRNPO", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 13, name: " Purchase order(Rate contract)", resource: "PurOrdersRateCont", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 14, name: "ReOrder Plan", resource: "PurReOrderPlan", rates: [1, 2, 3, 4, 5, 6, 8] }

];
const SubcontractorRateSettings = [
    { id: 15, name: "Open Order-Subcontract(Purchase)-Detailed", resource: "PurOpenOrderSub", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 16, name: "Order-Subcontract(Purchase)-Detailed", resource: "PurOrderSub", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 17, name: "PRN Based SCPO", resource: "PRNBsSCPO", rates: [1, 2, 3, 4, 5, 6, 8] },
    { id: 18, name: "Rate Contract - Subcontract(Purchase)", resource: "PurRateSubContract", rates: [1, 2, 3, 4, 5, 6, 8] }

];
const InventoryRateSettings = [
    { id: 18, name: "Bill Of Material", resource: "BOM", rates: [1, 2, 3, 5, 6, 11] },
    { id: 19, name: "Inward Against Order Receipt", resource: "INAgOR", rates: [4, 5, 9] },
    { id: 20, name: "Stock Adjustment Item Conversion", resource: "StAdItConv", rates: [9, 5, 6] }

];
const Modules = [{ id: 1, name: "Sales" },
{ id: 2, name: "Purchase" },
{ id: 3, name: "Sub-contractor" },
{ id: 4, name: "Inventory" }
];
const RequisitionDocType = [
    { id: 1, name: "MRN", displayname: "Material Requisition Note" },
    { id: 2, name: "PRN", displayname: "Purchase Requisition Note" }
];
const RequisitionIssueToType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Department", displayname: "Department" },
    { id: 3, name: "Employee", displayname: "Employee" },
    { id: 4, name: "SubContractor", displayname: "Sub Contractor" }
];
const StockReservationDocumentType = [
    { id: 1, name: "DispatchInstruction", displayname: "Dispatch Instruction" },
    { id: 1, name: "PackingSlip", displayname: "PackingSlip" },
    { id: 1, name: "JobCard", displayname: "JobCard" },
    { id: 1, name: "MaterialRequisition", displayname: "Material Requisition" }
];
const EnquiryStatus = [
    { id: 1, name: "New" },
    { id: 2, name: "Open" },
    { id: 3, name: "QuotationSent" },
    { id: 4, name: "OrderConverted" },
    { id: 5, name: "EnquiryLapsed" },
    { id: 6, name: "EnquiryCancelled" },
    { id: 7, name: "Lost" },
    { id: 8, name: "Regretted" },
    { id: 9, name: "QuotationReceived" },
    { id: 10, name: "OrderPlaced" }
];
const QuotationStatus = [
    { id: 1, name: "New" },
    { id: 2, name: "Open" },
    { id: 3, name: "OrderConverted" },
    { id: 4, name: "QuotationLapsed" },
    { id: 5, name: "QuotationCancelled" },
    { id: 6, name: "Lost" },
    { id: 7, name: "OrderPlaced" }
];
const OrderStatus = [
    { id: 1, name: "New" },
    { id: 2, name: "Open" },
    { id: 3, name: "Completed" },
    { id: 4, name: "ShortClosed" },
    { id: 5, name: "OrderFulfilled" },
    { id: 6, name: "OrderLapsed" },
    { id: 7, name: "OrderCancelled" },
    { id: 8, name: "Pending" }
];
const RejectionNoteSourceType = [
    { id: 1, name: "Supplier"       ,displayname: "Supplier"      },
    { id: 2, name: "Customer"       ,displayname: "Customer"      },
    { id: 3, name: "Department"     ,displayname: "Department"    } ,
    { id: 4, name: "Sub-Contractor" ,displayname: "Sub-Contractor" },
    
];
const RejectionRemarks = [
    { id: 1, name: "Accept", displayname: "Accept" },
    { id: 2, name: "AcceptAfterRework", displayname: "Accept after Rework" },
    { id: 3, name: "AcceptOnDeviation", displayname: "Accept on Deviation" },
    { id: 4, name: "AcceptWithRework", displayname: "Accept with Rework + Deviation" },
    { id: 5, name: "RejectedRework", displayname: "Rejected Rework" },
    { id: 6, name: "RejectedUnusable", displayname: "Rejected Unusable" },
    { id: 7, name: "Repair", displayname: "Repair" },
    { id: 8, name: "Replace", displayname: "Replace" },
    { id: 9, name: "ShortClose_Issue", displayname: "Short Close(Issue)" },
    { id: 10, name: "ShortClose_NoIssue", displayname: "Short Close(No Issue)" }
];
const SystemSettingsType = [
    { id: 1, name: "ComboBox", displayname: "ComboBox" },
    { id: 2, name: "CheckBox", displayname: "CheckBox" },
    { id: 3, name: "ListBox", displayname: "ListBox" },
    { id: 4, name: "TextBox", displayname: "TextBox" },
    { id: 5, name: "DatePicker", displayname: "DatePicker" },
];
const BillSource = [
    { id: 1, name: "Direct", displayname: "Direct" },
    { id: 2, name: "PurchaseOrder", displayname: "Purchase Order" },
    { id: 3, name: "InwardAgainstPO", displayname: "Inward Against PO" },
    { id: 4, name: "DirectInwardNote", displayname: "Direct Inward Note" }
];
const BillTransactionType = [
    { id: 1, name: "Manufacturer", displayname: "Manufacturer" },
    { id: 2, name: "UnregisteredDealer", displayname: "Unregistered Dealer" },
    { id: 3, name: "Import", displayname: "Import" }
];
const BillResponsibility = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Company", displayname: "Company" },
    { id: 3, name: "Supplier", displayname: "Supplier" }
];
const BillChargeBasis = [
    { id: 1, name: "PerDelivery", displayname: "Per Delivery" },
    { id: 2, name: "PerOrder", displayname: "Per Order" },
    //{ id: 3, name: "BasicPrice", displayname: "Basic Price" },
    { id: 3, name: "PerInvoice", displayname: "Per Invoice" }
];
const BillAddChrgProviderName = [
    { id: 1, name: "SelfCompany", displayname: "Self(Company)" },
    { id: 2, name: "SelfSupplier", displayname: "Self (Supplier)" }
];
const BillAddChrgDistributionBasis = [
    { id: 1, name: "Price", displayname: "Price" },
    { id: 2, name: "Quantity", displayname: "Quantity" }
];
const BillAddChrgPaymentBy = [
    { id: 1, name: "Invoice", displayname: "Invoice" },
    { id: 2, name: "Supplier", displayname: "Supplier" }
];
const BOMType = [
    { id: 1, name: "CostingBOM", displayname: "Costing BOM" },
    { id: 2, name: "ManufacturingBOM", displayname: "Manufacturing BOM" }
];
const MaterialIssueToType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Supplier", displayname: "Supplier" },
    { id: 3, name: "Sub-Contractor", displayname: "Sub-Contractor" },
    { id: 4, name: "Department", displayname: "Department" },
    { id: 5, name: "Employee", displayname: "Employee" },
];
const WarrantyTypes = [
    { id: 1, name: "FromDateOfMfg", displayname: "From date of Mfg" },
    { id: 2, name: "FromDateOfInvoice", displayname: "From date of Invoice" },
    { id: 3, name: "FromDateOfCommisioning", displayname: "From date of Commisioning" }
];
const DIStatus = [
    { id: 1, name: "New", displayname: "New" },
    { id: 2, name: "Open", displayname: "Open" },
    { id: 3, name: "Completed", displayname: "Completed" },
    { id: 5, name: "ShortClosed", displayname: "Short Closed" }
];
const ToleranceType = [
    { id: 1, name: "Fixed", displayname: "Fixed" },
    { id: 2, name: "MaxMin", displayname: "MaxMin" },
    { id: 3, name: "Percentage", displayname: "Percentage" }
];
const SalesPartnerType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "Dealer", displayname: "Dealer" },
    { id: 3, name: "SalesAgent", displayname: "Sales Agent" }
];
const PurchasePartnerType = [
    { id: 1, name: "Supplier", displayname: "Supplier" },
    { id: 2, name: "Dealer", displayname: "Dealer" },
    { id: 3, name: "SalesAgent", displayname: "Sales Agent" },
    { id: 4, name: "Sub-Contractor", displayname: "Sub-Contractor" },
    { id: 5, name: "Service-Provider", displayname: "Service Provider" },
    { id: 6, name: "Supplier-Subcontractor", displayname: "Supplier-Subcontractor" },
    { id: 7, name: "Supplier-Service-Provider", displayname: "Supplier-Service-Provider" }
];
const JobCardStatusMapping = [
    { id: 1, name: "Draft", displayname: "Draft" },
    { id: 2, name: "New", displayname: "New" },
    { id: 3, name: "Open", displayname: "Open" },
    { id: 4, name: "ShortClosed", displayname: "Short Closed" },
    { id: 5, name: "Completed", displayname: "Completed" }
];
const JobCardSourceDocType = [
    { id: 1, name: "Direct", displayname: "Draft" },
    { id: 2, name: "SalesOrder", displayname: "Sales Order" },
    { id: 3, name: "JobCard", displayname: "JobCard" }
];
const JobCardScopeOfSupply = [
    { id: 0, name: "PartList", displayname: "Part List" },
    { id: 1, name: "SOSQty1", displayname: "SOS 1" },
    { id: 2, name: "SOSQty2", displayname: "SOS 2" },
    { id: 3, name: "SOSQty3", displayname: "SOS 3" },
    { id: 4, name: "SOSQty4", displayname: "SOS 4" },
    { id: 5, name: "SOSQty5", displayname: "SOS 5" },
    { id: 6, name: "SOSQty6", displayname: "SOS 6" },
    { id: 7, name: "SOSQty7", displayname: "SOS 7" },
    { id: 8, name: "SOSQty8", displayname: "SOS 8" },
    { id: 9, name: "SOSQty9", displayname: "SOS 9" },
    { id: 10, name: "SOSQty10", displayname: "SOS 10" }
];
const BusinessFunctionType = [
    { id: 1, name: "Customer", displayname: "Customer" },
    { id: 2, name: "IndirectCustomer", displayname: "Indirect customer" },
    { id: 3, name: "Reseller", displayname: "Reseller" },
    { id: 4, name: "Supplier", displayname: "Supplier" },
    { id: 5, name: "SupplierIndirect", displayname: "Supplier-Indirect" },
    { id: 6, name: "SupplierReseller", displayname: "Supplier-Reseller" },
    { id: 7, name: "SupplierServiceProvider", displayname: "Supplier-Service Provider" },
    { id: 8, name: "SupplierSubContractor", displayname: "Supplier-Sub Contractor" },
    { id: 9, name: "ThirdPartyPurchase", displayname: "Third Party(Purchase)" },
    { id: 10, name: "ThirdPartySales", displayname: "Third Party(Sales)" }
];
const CarManufacturer = [
    { id: 1, name: "Porsche", displayname: "Porsche" },
    { id: 2, name: "BMW", displayname: "BMW" }
];
const CarType = [
    { id: 1, name: "911", displayname: "911" },
    { id: 2, name: "X3", displayname: "X3" },
    
];
export {
    SystemAddressType,
    EDocTypes,
    TaxRegistrationTypes,
    TaxRegionNames,
    TerritoryType,
    ResourceType,
    RecordStatus,
    EnquiryFor,
    QuotationSource,
    FunctionalTypes,
    Responsibility,
    DiscountType,
    PaymentMode,
    PaymentStatus,
    BusinessPatnerType,
    TaxRoundType,
    ExpressionType,
    AlertMessageType,
    AreaNames,
    InvoiceSource,
    InvoiceTypes,
    GSTInvoiceType,
    InvoiceMethodOfTransaction,
    TaxRoundToValue,
    AdditionalChargeSource,
    DirectInwardSourceType,
    InwardConditions,
    InwardActionTypes,
    InwardStockingTypes,
    InwardStatus,
    InvoiceTypeList,
    InvoiceDocType,
    DeducteeType,
    PackingUnit,
    SupplierProductStatus,
    PurchaseLeadTimeFormat,
    PackingUnitRoundingType,
    RateContract,
    DocumentTypes,
    QCInwardTypes,
    AcceptType,
    RejectType,
    DocumentIDs,
    ActionTypeFor,
    SalesRateSettings,
    PurchaseRateSettings,
    SubcontractorRateSettings,
    InventoryRateSettings,
    Modules,
    RequisitionDocType,
    RequisitionIssueToType,
    StockReservationDocumentType,
    EnquiryStatus,
    QuotationStatus,
    OrderStatus,
    RejectionNoteSourceType,
    RejectionRemarks,
    SystemSettingsType,
    BillSource,
    BillTransactionType,
    BillResponsibility,
    BillChargeBasis,
    BillAddChrgProviderName,
    BillAddChrgDistributionBasis,
    BillAddChrgPaymentBy,
    BOMType,
    MaterialIssueToType,
    WarrantyTypes,
    DIStatus,
    ToleranceType,
    SalesPartnerType,
    PurchasePartnerType,
    BOMLeadTime,
    JobCardStatusMapping,
    JobCardSourceDocType,
    JobCardScopeOfSupply,
    BusinessFunctionType,
	Gender,
	CarManufacturer,
	CarType
};