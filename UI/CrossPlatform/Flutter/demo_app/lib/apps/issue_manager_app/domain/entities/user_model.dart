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
        if (id != null) "id": id,
        if (firstName != null) "firstName": firstName,
        if (lastName != null) "lastName": lastName,
        if (gender != null) "gender": gender,
        if (birthDate != null) "birthDate": birthDate,
        if (age != null) "age": age,
        if (phone != null) "phone": phone,
        if (address != null) "address": address,
        if (department != null) "department": department,
        if (designation != null) "designation": designation,
        if (position != null) "position": position,
        if (img != null) "img": img,
        if (email != null) "email": email,
        if (password != null) "password": password,
        if (tokenCreated != null) "tokenCreated": tokenCreated,
        if (tokenExpires != null) "tokenExpires": tokenExpires,
        if (refreshToken != null) "refreshToken": refreshToken,
        if (role != null) "role": role,
        if (isActive != null) "isActive": isActive,
        if (createdOn != null) "createdOn": createdOn,
        if (modifiedOn != null) "modifiedOn": modifiedOn,
        if (createdBy != null) "createdBy": createdBy,
        if (modifiedBy != null) "modifiedBy": modifiedBy,
      };
}
