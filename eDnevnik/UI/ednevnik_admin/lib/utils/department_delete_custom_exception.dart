class DepartmentDeleteException implements Exception {
  final String message;
  DepartmentDeleteException(this.message);
  @override
  String toString() => 'DepartmentDeleteException: $message';
}
