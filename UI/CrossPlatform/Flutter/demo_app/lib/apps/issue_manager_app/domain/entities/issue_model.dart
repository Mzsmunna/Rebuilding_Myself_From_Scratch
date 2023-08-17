class IssueModel {
  String? id;
  String? projectId;
  String? title;
  String? type;
  String? summary;
  String? description;
  String? assignedName;
  String? assignedImg;
  String? assignedId;
  int? logTime;
  DateTime? startDate;
  DateTime? endDate;
  DateTime? dueDate;
  String? status;
  String? comment;
  bool? isActive;
  bool? isDeleted;
  bool? isCompleted;
  DateTime? createdOn;
  DateTime? modifiedOn;
  String? createdBy;
  String? createdByName;
  String? createdByImg;
  String? modifiedBy;

  IssueModel() {
    id = "";
    projectId = "";
    title = "";
    type = "";
    summary = "";
    description = "";
    assignedName = "";
    assignedImg = "";
    assignedId = "";
    logTime = 0;
    startDate = null;
    endDate = null;
    dueDate = null;
    status = "";
    comment = "";
    isActive = true;
    isDeleted = false;
    isCompleted = false;
    createdOn = DateTime.now();
    modifiedOn = null;
    createdBy = "";
    createdByName = "";
    createdByImg = "";
    modifiedBy = "";
  }

  IssueModel.create(
      {this.id,
      this.projectId,
      this.title,
      this.type,
      this.summary,
      this.description,
      this.assignedName,
      this.assignedImg,
      this.assignedId,
      this.logTime,
      this.startDate,
      this.endDate,
      this.dueDate,
      this.status,
      this.comment,
      this.isActive,
      this.isDeleted,
      this.isCompleted,
      this.createdOn,
      this.modifiedOn,
      this.createdBy,
      this.createdByName,
      this.createdByImg,
      this.modifiedBy});

  IssueModel.fromJson(Map<String, dynamic> json) {
    id = json['Id'] ?? json['Id'];
    projectId = json['ProjectId'] ?? json['ProjectId'];
    title = json['Title'] ?? json['Title'];
    type = json['Type'] ?? json['Type'];
    summary = json['Summary'] ?? json['Summary'];
    description = json['Description'] ?? json['Description'];
    assignedName = json['AssignedName'] ?? json['AssignedName'];
    assignedImg = json['AssignedImg'] ?? json['AssignedImg'];
    assignedId = json['AssignedId'] ?? json['AssignedId'];
    logTime = json['LogTime'] ?? json['LogTime'] as int?;
    startDate =
        json['StartDate'] == null ? null : DateTime.tryParse(json['StartDate']);
    endDate =
        json['EndDate'] == null ? null : DateTime.tryParse(json['EndDate']);
    dueDate =
        json['DueDate'] == null ? null : DateTime.tryParse(json['DueDate']);
    status = json['Status'] ?? json['Status'];
    comment = json['Comment'] ?? json['Comment'];
    isActive = json['IsActive'] ?? json['IsActive'] as bool;
    isDeleted = json['IsDeleted'] ?? json['IsDeleted'] as bool;
    isCompleted = json['IsCompleted'] ?? json['IsCompleted'] as bool;
    createdOn =
        json['CreatedOn'] == null ? null : DateTime.tryParse(json['CreatedOn']);
    modifiedOn = json['ModifiedOn'] == null
        ? null
        : DateTime.tryParse(json['ModifiedOn']);
    createdBy = json['CreatedBy'] ?? json['CreatedBy'];
    createdByName = json['CreatedByName'] ?? json['CreatedByName'];
    createdByImg = json['CreatedByImg'] ?? json['CreatedByImg'];
    modifiedBy = json['ModifiedBy'] ?? json['ModifiedBy'];
  }

  Map<String, dynamic> toJson() => {
        "Id": id ?? "",
        "ProjectId": projectId ?? projectId,
        "Title": title ?? title,
        "Type": type ?? type,
        "Summary": summary ?? summary,
        "Description": description ?? description,
        "AssignedName": assignedName ?? assignedName,
        "AssignedImg": assignedImg ?? assignedImg,
        "AssignedId": assignedId ?? assignedId,
        "LogTime": logTime ?? logTime,
        "StartDate": startDate == null ? null : startDate!.toIso8601String(),
        "EndDate": endDate == null ? null : endDate!.toIso8601String(),
        "DueDate": dueDate == null ? null : dueDate!.toIso8601String(),
        "Status": status ?? status,
        "Comment": comment ?? comment,
        "IsActive": isActive ?? isActive,
        "IsDeleted": isDeleted ?? isDeleted,
        "IsCompleted": isCompleted ?? isCompleted,
        "CreatedOn": createdOn == null ? null : createdOn!.toIso8601String(),
        "ModifiedOn": modifiedOn == null ? null : modifiedOn!.toIso8601String(),
        "CreatedBy": createdBy ?? createdBy,
        "CreatedByName": createdByName ?? createdByName,
        "CreatedByImg": createdByImg ?? createdByImg,
        "ModifiedBy": modifiedBy ?? modifiedBy,
      };
}
