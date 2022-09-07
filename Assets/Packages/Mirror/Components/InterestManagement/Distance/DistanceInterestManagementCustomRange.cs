// add this to NetworkIdentities for custom range if needed.
// only works with DistanceInterestManagement.
using Packages.Mirror.Runtime;
using UnityEngine;

namespace Packages.Mirror.Components.InterestManagement.Distance
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Network/ Interest Management/ Distance/Distance Custom Range")]
    [HelpURL("https://mirror-networking.gitbook.io/docs/guides/interest-management")]
    public class DistanceInterestManagementCustomRange : NetworkBehaviour
    {
        [Tooltip("The maximum range that objects will be visible at.")]
        public int visRange = 20;
    }
}
