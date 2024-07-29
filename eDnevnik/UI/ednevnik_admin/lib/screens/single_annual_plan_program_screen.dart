import 'package:ednevnik_admin/models/annual_plan_program.dart';
import 'package:flutter/material.dart';

class SingleAnnualPlanProgramScreen extends StatelessWidget {
  final AnnualPlanProgram? planProgram;

  const SingleAnnualPlanProgramScreen({Key? key, this.planProgram}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(planProgram?.naziv ?? "New Plan and Program"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text("Naziv: ${planProgram?.naziv ?? ''}"),
            Text("Broj Časova: ${planProgram?.brojCasova ?? ''}"),
          ],
        ),
      ),
    );
  }
}
