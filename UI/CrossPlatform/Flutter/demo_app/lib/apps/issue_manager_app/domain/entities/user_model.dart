// ignore_for_file: public_member_api_docs, sort_constructors_first

class UserModel {
  String? id;
  String? firstName;
  String? lastName;
  String? gender;
  DateTime? birthDate;
  int? age;
  String? phone;
  String? address;
  String? department;
  String? designation;
  String? position;
  String? img;
  String? email;
  String? password;
  //Byte[] passwordHash;
  //Byte[] passwordSalt;
  DateTime? tokenCreated;
  DateTime? tokenExpires;
  String? refreshToken;
  String? role;
  bool? isActive;
  DateTime? createdOn;
  DateTime? modifiedOn;
  String? createdBy;
  String? modifiedBy;

  UserModel() {
    id = "";
    firstName = "";
    lastName = "";
    gender = "";
    age = 0;
    phone = "";
    birthDate = null;
    address = "";
    department = "";
    designation = "";
    position = "";
    img = "";
    email = "";
    password = "";
    //passwordHash = [];
    //passwordSalt = [];
    tokenCreated = null;
    tokenExpires = null;
    refreshToken = "";
    role = "";
    isActive = true;
    createdOn = DateTime.now();
    modifiedOn = null;
    createdBy = "";
    modifiedBy = "";
  }

  UserModel.create({
    this.id,
    this.firstName,
    this.lastName,
    this.gender,
    this.birthDate,
    this.age,
    this.phone,
    this.address,
    this.department,
    this.designation,
    this.position,
    this.img,
    this.email,
    this.password,
    //this.passwordHash,
    //this.passwordSalt,
    this.tokenCreated,
    this.tokenExpires,
    this.refreshToken,
    this.role,
    this.isActive,
    this.createdOn,
    this.modifiedOn,
    this.createdBy,
    this.modifiedBy,
  });

  UserModel.fromJson(Map<String, dynamic> json) {
    id = json['Id'] ?? json['Id'];
    firstName = json['FirstName'] ?? json['FirstName'];
    lastName = json['LastName'] ?? json['LastName'];
    gender = json['Gender'] ?? json['Gender'];
    birthDate =
        json['BirthDate'] == null ? null : DateTime.tryParse(json['BirthDate']);
    age = json['Age'] ?? json['Age'] as int?;
    phone = json['Phone'] ?? json['Phone'];
    address = json['Address'] ?? json['Address'];
    department = json['Department'] ?? json['Department'];
    designation = json['Designation'] ?? json['Designation'];
    position = json['Position'] ?? json['Position'];
    img = json['Img'] ?? json['Img'];
    email = json['Email'] ?? json['Email'];
    password = json['Password'] ?? json['Password'];
    tokenCreated = json['TokenCreated'] == null
        ? null
        : DateTime.tryParse(json['TokenCreated']);
    tokenExpires = json['TokenExpires'] == null
        ? null
        : DateTime.tryParse(json['TokenExpires']);
    refreshToken = json['TefreshToken'] ?? json['TefreshToken'];
    role = json['Role'] ?? json['Role'];
    isActive = json['IsActive'] ?? json['IsActive'] as bool;
    createdOn =
        json['CreatedOn'] == null ? null : DateTime.tryParse(json['CreatedOn']);
    modifiedOn = json['ModifiedOn'] == null
        ? null
        : DateTime.tryParse(json['ModifiedOn']);
    createdBy = json['CreatedBy'] ?? json['CreatedBy'];
    modifiedBy = json['ModifiedBy'] ?? json['ModifiedBy'];
  }

  Map<String, dynamic> toJson() => {
        "Id": id ?? "",
        "FirstName": firstName ?? firstName,
        "LastName": lastName ?? lastName,
        "Gender": gender ?? gender,
        "BirthDate": birthDate == null ? null : birthDate!.toIso8601String(),
        "Age": age ?? age,
        "Phone": phone ?? phone,
        "Address": address ?? address,
        "Department": department ?? department,
        "Designation": designation ?? designation,
        "Position": position ?? position,
        "Img": img ?? img,
        "Email": email ?? email,
        "Password": password ?? password,
        "TokenCreated": tokenCreated ?? tokenCreated,
        "TokenExpires": tokenExpires ?? tokenExpires,
        "RefreshToken": refreshToken ?? refreshToken,
        "Role": role ?? role,
        "IsActive": isActive ?? isActive,
        "CreatedOn": createdOn == null ? null : createdOn!.toIso8601String(),
        "ModifiedOn": modifiedOn == null ? null : modifiedOn!.toIso8601String(),
        "CreatedBy": createdBy ?? createdBy,
        "ModifiedBy": modifiedBy ?? modifiedBy,
      };
}
