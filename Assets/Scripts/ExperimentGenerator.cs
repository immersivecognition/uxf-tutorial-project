using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ExperimentGenerator : MonoBehaviour
{     
    public void Generate(Session session)
    {
        // generate our three blocks

        int nPractice = session.settings.GetInt("practice_ntrials");
        Block practice = session.CreateBlock(nPractice);
        practice.settings.SetValue("vmr_angle", 0);
        practice.settings.SetValue("clamped_error", false);
        practice.settings.SetValue("timeout_period", 2.0); // more time in practice

        int nPert = session.settings.GetInt("perturbation_ntrials");
        Block pert = session.CreateBlock(nPert);

        int nDeadapt = session.settings.GetInt("deadapt_ntrials");
        Block deadapt = session.CreateBlock(nDeadapt);
        deadapt.settings.SetValue("vmr_angle", 0);
        deadapt.settings.SetValue("clamped_error", false);
    }
}