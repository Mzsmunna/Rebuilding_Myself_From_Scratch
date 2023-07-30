import 'dart:io';
import 'package:flutter/material.dart';
import 'package:image_cropper/image_cropper.dart';
import 'package:image_picker/image_picker.dart';
import 'package:permission_handler/permission_handler.dart';
import 'package:flutter/foundation.dart' show defaultTargetPlatform, kIsWeb;

ValueNotifier<File?> selectedImageFile = ValueNotifier(null);

class ImageCaptureOrPickerWidget extends StatefulWidget {
  const ImageCaptureOrPickerWidget({super.key});

  @override
  State<ImageCaptureOrPickerWidget> createState() =>
      _ImageCaptureOrPickerWidgetState();
}

class _ImageCaptureOrPickerWidgetState
    extends State<ImageCaptureOrPickerWidget> {
  final picker = ImagePicker();
  File? imageFile;

  void _chooseAnImage() async {
    //setState(() {});
    Map<Permission, PermissionStatus> statuses = await [
      Permission.storage,
      Permission.camera,
    ].request();
    if (statuses[Permission.storage]!.isGranted &&
        statuses[Permission.camera]!.isGranted) {
      showImagePicker(context);
    } else {
      print('no permission provided');
    }
  }

  void showImagePicker(BuildContext context) {
    showModalBottomSheet(
        context: context,
        builder: (builder) {
          return Card(
            child: Container(
                width: MediaQuery.of(context).size.width,
                height: MediaQuery.of(context).size.height / 5.2,
                margin: const EdgeInsets.only(top: 8.0),
                padding: const EdgeInsets.all(12),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Expanded(
                        child: InkWell(
                      child: const Column(
                        children: [
                          Icon(
                            Icons.image,
                            size: 60.0,
                          ),
                          SizedBox(height: 12.0),
                          Text(
                            "Gallery",
                            textAlign: TextAlign.center,
                            style: TextStyle(
                              fontSize: 16,
                            ),
                          )
                        ],
                      ),
                      onTap: () {
                        _imgFromGallery();
                        Navigator.pop(context);
                      },
                    )),
                    Expanded(
                        child: InkWell(
                      child: const SizedBox(
                        child: Column(
                          children: [
                            Icon(
                              Icons.camera_alt,
                              size: 60.0,
                            ),
                            SizedBox(height: 12.0),
                            Text(
                              "Camera",
                              textAlign: TextAlign.center,
                              style: TextStyle(
                                fontSize: 16,
                              ),
                            )
                          ],
                        ),
                      ),
                      onTap: () {
                        _imgFromCamera();
                        Navigator.pop(context);
                      },
                    ))
                  ],
                )),
          );
        });
  }

  _imgFromGallery() async {
    await picker
        .pickImage(source: ImageSource.gallery, imageQuality: 50)
        .then((value) {
      if (value != null) {
        _updateImage(File(value.path));
      }
    });
  }

  _imgFromCamera() async {
    await picker
        .pickImage(source: ImageSource.camera, imageQuality: 50)
        .then((value) {
      if (value != null) {
        _updateImage(File(value.path));
      }
    });
  }

  _updateImage(File imgFile) {
    if (kIsWeb) {
      setState(() {
        selectedImageFile.value = imageFile;
      });
    } else if (defaultTargetPlatform == TargetPlatform.android) {
      _cropImage(imgFile);
    } else if (defaultTargetPlatform == TargetPlatform.iOS) {
      _cropImage(imgFile);
    } else if (defaultTargetPlatform == TargetPlatform.fuchsia) {
      setState(() {
        selectedImageFile.value = imageFile;
      });
    } else if (defaultTargetPlatform == TargetPlatform.linux) {
      setState(() {
        selectedImageFile.value = imageFile;
      });
    } else if (defaultTargetPlatform == TargetPlatform.windows) {
      setState(() {
        selectedImageFile.value = imageFile;
      });
    } else if (defaultTargetPlatform == TargetPlatform.macOS) {
      setState(() {
        selectedImageFile.value = imageFile;
      });
    }
  }

  _cropImage(File imgFile) async {
    final croppedFile = await ImageCropper().cropImage(
        sourcePath: imgFile.path,
        aspectRatioPresets: Platform.isAndroid
            ? [
                CropAspectRatioPreset.square,
                CropAspectRatioPreset.ratio3x2,
                CropAspectRatioPreset.original,
                CropAspectRatioPreset.ratio4x3,
                CropAspectRatioPreset.ratio16x9
              ]
            : [
                CropAspectRatioPreset.original,
                CropAspectRatioPreset.square,
                CropAspectRatioPreset.ratio3x2,
                CropAspectRatioPreset.ratio4x3,
                CropAspectRatioPreset.ratio5x3,
                CropAspectRatioPreset.ratio5x4,
                CropAspectRatioPreset.ratio7x5,
                CropAspectRatioPreset.ratio16x9
              ],
        uiSettings: [
          AndroidUiSettings(
              toolbarTitle: "Image Cropper",
              toolbarColor: Colors.blueAccent,
              toolbarWidgetColor: Colors.white,
              initAspectRatio: CropAspectRatioPreset.original,
              lockAspectRatio: false),
          IOSUiSettings(
            title: "Image Cropper",
          )
        ]);
    if (croppedFile != null) {
      imageCache.clear();
      //selectedImageFile.value = croppedFile.path;
      setState(() {
        imageFile = File(croppedFile.path);
        selectedImageFile.value = imageFile;
      });
      // reload();
    }
  }

  @override
  Widget build(BuildContext context) {
    return FloatingActionButton(
      heroTag: "image_capture_or_picker",
      onPressed: _chooseAnImage,
      tooltip: 'choose image',
      child: const Icon(Icons.camera),
    );
  }
}
