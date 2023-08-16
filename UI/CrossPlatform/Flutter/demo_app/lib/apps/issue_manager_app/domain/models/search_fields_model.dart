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
        "key": key ?? "",
        "value": value ?? "",
        "dataType": dataType ?? "",
        "dataSeparator": dataSeparator ?? "",
        "isId": isId ?? false,
        "isString": isString ?? true,
        "isCaseSensitive": isCaseSensitive ?? false,
        "isPartialMatch": isPartialMatch ?? false,
        "isBoolean": isBoolean ?? false,
        "isDateTime": isDateTime ?? false,
        "isAndQuery": isAndQuery ?? true,
        "isEncrypted": isEncrypted ?? false,
        "queryOrder": queryOrder ?? 0,
        "currentPage": currentPage ?? 0,
        "pageSize": pageSize ?? 0,
        "sortField": sortField ?? "",
        "sortDirection": sortDirection ?? "",
      };
}
