class MaxItemsExceededException implements Exception {
  final String message;
  MaxItemsExceededException(this.message);
  @override
  String toString() => 'MaxItemsExceededException: $message';
}
