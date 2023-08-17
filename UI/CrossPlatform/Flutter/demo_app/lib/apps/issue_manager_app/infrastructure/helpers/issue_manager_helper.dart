import 'dart:convert';

import 'package:demo_app/apps/issue_manager_app/domain/models/search_fields_model.dart';

class IssueManagerHelper {
  static String getSearchQueriesjsonEncode(
      List<SearchFieldModel> searchQueries) {
    String searchQueriesString =
        jsonEncode(searchQueries.map((e) => e.toJson()).toList());
    searchQueriesString = Uri.encodeFull(searchQueriesString);

    return searchQueriesString;
  }
}
