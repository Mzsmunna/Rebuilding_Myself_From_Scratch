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

  UserModel({
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
}
