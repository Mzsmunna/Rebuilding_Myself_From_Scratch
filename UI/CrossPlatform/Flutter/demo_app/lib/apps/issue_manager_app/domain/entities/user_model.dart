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

  UserModel.copy({
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

  Map<String, dynamic> toJson() => {
        "id": id ?? "",
        "firstName": firstName ?? firstName,
        "lastName": lastName ?? lastName,
        "gender": gender ?? gender,
        "birthDate": birthDate == null ? null : birthDate!.toIso8601String(),
        "age": age ?? age,
        "phone": phone ?? phone,
        "address": address ?? address,
        "department": department ?? department,
        "designation": designation ?? designation,
        "position": position ?? position,
        "img": img ?? img,
        "email": email ?? email,
        "password": password ?? password,
        "tokenCreated": tokenCreated ?? tokenCreated,
        "tokenExpires": tokenExpires ?? tokenExpires,
        "refreshToken": refreshToken ?? refreshToken,
        "role": role ?? role,
        "isActive": isActive ?? isActive,
        "createdOn": createdOn == null ? null : createdOn!.toIso8601String(),
        "modifiedOn": modifiedOn == null ? null : modifiedOn!.toIso8601String(),
        "createdBy": createdBy ?? createdBy,
        "modifiedBy": modifiedBy ?? modifiedBy,
      };
}
