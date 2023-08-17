class SearchFieldModel {
  String? key;
  String? value;
  String? dataType;
  String? dataSeparator;
  bool? isId;
  bool? isString;
  bool? isCaseSensitive;
  bool? isPartialMatch;
  bool? isBoolean;
  bool? isDateTime;
  bool? isAndQuery;
  bool? isEncrypted;
  int? queryOrder;
  int? currentPage;
  int? pageSize;
  String? sortField;
  String? sortDirection;

  SearchFieldModel() {
    key = "";
    value = "";
    dataType = "";
    dataSeparator = "";
    isId = false;
    isString = true;
    isCaseSensitive = false;
    isPartialMatch = false;
    isBoolean = false;
    isDateTime = false;
    isAndQuery = true;
    isEncrypted = false;
    queryOrder = 0;
    currentPage = 0;
    pageSize = 0;
    sortField = "";
    sortDirection = "";
  }

  Map<String, dynamic> toJson() => {
        "Key": key ?? "",
        "Value": value ?? "",
        "DataType": dataType ?? "",
        "DataSeparator": dataSeparator ?? "",
        "IsId": isId ?? false,
        "IsString": isString ?? true,
        "IsCaseSensitive": isCaseSensitive ?? false,
        "IsPartialMatch": isPartialMatch ?? false,
        "IsBoolean": isBoolean ?? false,
        "IsDateTime": isDateTime ?? false,
        "IsAndQuery": isAndQuery ?? true,
        "IsEncrypted": isEncrypted ?? false,
        "QueryOrder": queryOrder ?? 0,
        "CurrentPage": currentPage ?? 0,
        "PageSize": pageSize ?? 0,
        "SortField": sortField ?? "",
        "SortDirection": sortDirection ?? "",
      };
}
