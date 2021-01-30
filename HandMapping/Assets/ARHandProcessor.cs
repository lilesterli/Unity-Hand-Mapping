using UnityEngine;

public class ARHandProcessor : MonoBehaviour {
    private GameObject Hand = default;
    private ARHand currentHand = default;

    void Start() {
        Hand = GameObject.Find("HandOnSpace");
        currentHand = new ARHand();
    }

    public void Map() {
        //float[] handLandmarksData =  { 0.3526872f, 0.6270964f, -0.0004601479f, 0.4511237f, 0.5807911f, -8.679688f, 0.5035025f, 0.5214234f, -10.91406f, 0.5150174f, 0.467426f, -13.07813f, 0.5117438f, 0.4256829f, -14.83594f, 0.4080766f, 0.4619312f, 2.869141f, 0.4253039f, 0.4035826f, 3.820313f, 0.4315633f, 0.3622928f, 2.527344f, 0.4356762f, 0.3286943f, 0.902832f, 0.3228855f, 0.464197f, 4.074219f, 0.3191571f, 0.4026566f, 5.886719f, 0.3154154f, 0.3582191f, 3.480469f, 0.3145045f, 0.3243451f, 1.486328f, 0.2484229f, 0.4766589f, 3.324219f, 0.2233877f, 0.4227916f, 4.195313f, 0.2111338f, 0.3823428f, 2.017578f, 0.207127f, 0.3521281f, 0.317627f, 0.1815808f, 0.4986128f, 1.121094f, 0.1356988f, 0.4593594f, 0.4775391f, 0.1123892f, 0.4283063f, -1.147461f, 0.09953429f, 0.4001474f, -2.267578f };
        //double[] data = { 0.4035175, 0.5062346, -0.0004014969, 0.4365276, 0.4557825, -2.785156, 0.4428939, 0.417715, -0.5546875, 0.4309197, 0.3871776, 0.8666992, 0.4195504, 0.3608807, 2.365234, 0.3802218, 0.4141552, 17.53125, 0.3564025, 0.3803404, 23.35938, 0.3350466, 0.3583718, 26.625, 0.3136753, 0.3426101, 29.28125, 0.333729, 0.4284126, 19.625, 0.3031071, 0.3952224, 28.17188, 0.2800342, 0.3726654, 31.60938, 0.2610509, 0.3571787, 34.875, 0.2937769, 0.4451961, 19.75, 0.261823, 0.4196663, 27.20313, 0.2395864, 0.3984017, 30.45313, 0.2232063, 0.3833297, 33.21875, 0.2595712, 0.464071, 18.8125, 0.2237256, 0.4467771, 24.5625, 0.2027811, 0.432457, 27.59375, 0.1879436, 0.4201182, 30.57813 };
        double[] data ={0.47290486097335815, 0.8024421334266663, -3.080353781115264e-05
, 0.6748874187469482, 0.7071064710617065, 0.036318957805633545
, 0.7533493041992188, 0.6176501512527466, 0.11098148673772812
, 0.7564226388931274, 0.5248629450798035, 0.16142506897449493
, 0.7809327244758606, 0.4587807357311249, 0.22036997973918915
, 0.5696510076522827
, 0.5340731143951416
, 0.3157427906990051
, 0.5503242015838623
, 0.41534680128097534
, 0.3680669963359833
, 0.5268571376800537
, 0.35315197706222534
, 0.35879039764404297
, 0.5099781155586243
, 0.30950844287872314
, 0.3476531505584717
, 0.46446681022644043
, 0.5321977138519287
, 0.2842313349246979
, 0.453653484582901
, 0.402823269367218
, 0.3386566638946533
, 0.4399282932281494
, 0.32297614216804504
, 0.2843918204307556
, 0.4308456480503082
, 0.26497408747673035
, 0.23571307957172394
, 0.3682490289211273
, 0.5467028617858887
, 0.23450419306755066
, 0.35848289728164673
, 0.4284166693687439
, 0.26107317209243774
, 0.3598310053348541
, 0.3499809801578522
, 0.21005958318710327
, 0.3618050217628479
, 0.28700533509254456
, 0.1623281091451645
, 0.26791876554489136
, 0.5747754573822021
, 0.1774550974369049
, 0.259296178817749
, 0.48038604855537415
, 0.172262042760849
, 0.2712602913379669
, 0.421069860458374
, 0.13122546672821045
, 0.2830103039741516
, 0.3688952326774597
, 0.09042453020811081}; 
        float[] handLandmarksData = new float[63];
        float ImageRatio = 1;

        for (int i=0; i<63;i++)
            handLandmarksData[i] = (float)data[i];

        if (null != handLandmarksData && !float.IsNegativeInfinity(ImageRatio)) {
            currentHand.ParseFrom(handLandmarksData, ImageRatio);
        }

        if (!Hand.activeInHierarchy) return;
        for (int i = 0; i < Hand.transform.childCount; i++) {
            Hand.transform.GetChild(i).transform.position = currentHand.GetLandmark(i);
        }
    }
    public ARHand CurrentHand { get => currentHand; }
}