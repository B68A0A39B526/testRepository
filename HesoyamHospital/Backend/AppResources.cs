using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DoctorModel;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Repository.MySQLRepository.MedicalRepository;
using Backend.Repository.MySQLRepository.MiscRepository;
using Backend.Repository.MySQLRepository.UsersRepository;
using Backend.Repository.Sequencer;
using Backend.Service.HospitalManagementService;
using Backend.Service.MedicalService;
using Backend.Service.MiscService;
using Backend.Service.UsersService;
using Backend.Util;
using Backend.Model.PharmacyModel;

namespace Backend
{
    public class AppResources
    {
        public User loggedInUser;

        private static AppResources instance = null;

        #region Repositories
        public UserRepository userRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ManagerRepository managerRepository;
        public SecretaryRepository secretaryRepository;
        public TimeTableRepository timeTableRepository;
        public HospitalRepository hospitalRepository;
        public RoomRepository roomRepository;
        public InventoryItemRepository inventoryItemRepository;
        public DoctorStatisticRepository doctorStatisticRepository;
        public InventoryStatisticsRepository inventoryStatisticRepository;
        public RoomStatisticsRepository roomStatisticRepository;
        public InventoryRepository inventoryRepository;

        //Misc repositories
        public LocationRepository locationRepository;
        public NotificationRepository notificationRepository;
        public MessageRepository messageRepository;
        public ArticleRepository articleRepository;
        public QuestionRepository questionRepository;
        public QuestionRepository doctorQuestionRepository;
        public FeedbackRepository feedbackRepository;
        public DoctorFeedbackRepository doctorFeedbackRepository;

        public RegisteredPharmacyRepository registeredPharmacyRepository;

        public SurveyRepository surveyRepository;


        //Hospital management
        public MedicineRepository medicineRepository;

        //Medical repositories
        public AllergyRepository allergyRepository;
        public AppointmentRepository appointmentRepository;
        public DiagnosisRepository diagnosisRepository;
        public DiseaseRepository diseaseRepository;
        public IngredientRepository ingredientRepository;
        public MedicalRecordRepository medicalRecordRepository;
        public PrescriptionRepository prescriptionRepository;
        public ReportRepository reportRepository;
        public SymptomRepository symptomRepository;
        public TherapyRepository therapyRepository;

        #endregion Repositories

        public IAppointmentStrategy appointmentStrategy;

        #region service definitions
        // HospitalManagementServices
        public DoctorStatisticsService doctorStatisticsService;
        public InventoryStatisticsService inventoryStatisticsService;
        public RoomStatisticsService roomStatisticsService;
        public HospitalService hospitalService;
        public InventoryService inventoryService;
        public MedicineService medicineService;
        public RoomService roomService;

        // MedicalService
        public AppointmentService appointmentService;
        public AppointmentRecommendationService appointmentRecommendationService;
        public DiagnosisService diagnosisService;
        public DiseaseService diseaseService;
        public MedicalRecordService medicalRecordService;
        public TherapyService therapyService;

        // MiscService
        public ArticleService articleService;
        public DoctorFeedbackService doctorFeedbackService;
        public FeedbackService feedbackService;
        public SurveyService surveyService;
        public LocationService locationService;
        public MessageService messageService;
        public NotificationService notificationService;
        public AppointmentNotificationSender appointmentNotificationSender;
        public RegisteredPharmacyService registeredPharmacyService;

        // UsersService
        public DoctorService doctorService;
        public ManagerService managerService;
        public PatientService patientService;
        public SecretaryService secretaryService;
        public UserService userService;
        #endregion


        private AppResources()
        {
            LoadRepositories();
            LoadServices();
        }

        private void LoadServices()
        {
            // HospitalManagementService
            doctorStatisticsService = new DoctorStatisticsService(doctorStatisticRepository);
            inventoryStatisticsService = new InventoryStatisticsService(inventoryStatisticRepository);
            roomStatisticsService = new RoomStatisticsService(roomStatisticRepository);
            hospitalService = new HospitalService(hospitalRepository);
            inventoryService = new InventoryService(inventoryRepository, inventoryItemRepository, medicineRepository);
            roomService = new RoomService(roomRepository, appointmentRepository);
            medicineService = new MedicineService(medicineRepository);

            // MedicineService
            diagnosisService = new DiagnosisService(diagnosisRepository);
            diseaseService = new DiseaseService(diseaseRepository);
            medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            therapyService = new TherapyService(therapyRepository, medicalRecordService);

            // MiscService
            articleService = new ArticleService(articleRepository);
            doctorFeedbackService = new DoctorFeedbackService(doctorFeedbackRepository);

            feedbackService = new FeedbackService(feedbackRepository, questionRepository);
            surveyService = new SurveyService(surveyRepository);
            locationService = new LocationService(locationRepository);
            messageService = new MessageService(messageRepository);
            notificationService = new NotificationService(notificationRepository);
            appointmentNotificationSender = new AppointmentNotificationSender(notificationService);
            appointmentService = new AppointmentService(appointmentRepository, appointmentStrategy, appointmentNotificationSender);
            registeredPharmacyService = new RegisteredPharmacyService(registeredPharmacyRepository);

            // UsersService
            doctorService = new DoctorService(doctorRepository, userRepository, appointmentService);
            managerService = new ManagerService(managerRepository);
            patientService = new PatientService(patientRepository, medicalRecordRepository);
            secretaryService = new SecretaryService(secretaryRepository);
            userService = new UserService(userRepository);

            appointmentRecommendationService = new AppointmentRecommendationService(appointmentService, doctorService);
        }

        private void LoadRepositories()
        {
            userRepository = new UserRepository(new MySQLStream<User>(), new LongSequencer());
            hospitalRepository = new HospitalRepository(new MySQLStream<Hospital>(), new LongSequencer());
            doctorRepository = new DoctorRepository(new MySQLStream<Doctor>(), new LongSequencer(), userRepository);
            patientRepository = new PatientRepository(new MySQLStream<Patient>(), new LongSequencer(), doctorRepository, userRepository);
            locationRepository = new LocationRepository(new MySQLStream<Location>(), new LongSequencer());
            feedbackRepository = new FeedbackRepository(new MySQLStream<Feedback>(), new LongSequencer());
            medicineRepository = new MedicineRepository(new MySQLStream<Medicine>(), new LongSequencer());
            prescriptionRepository = new PrescriptionRepository(new MySQLStream<Prescription>(), new LongSequencer());
            reportRepository = new ReportRepository(new MySQLStream<Report>(), new LongSequencer());
            allergyRepository = new AllergyRepository(new MySQLStream<Allergy>(), new LongSequencer());
            medicalRecordRepository = new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new LongSequencer());
            diagnosisRepository = new DiagnosisRepository(new MySQLStream<Diagnosis>(), new LongSequencer());
            surveyRepository = new SurveyRepository(new MySQLStream<Survey>(), new LongSequencer());
            

            registeredPharmacyRepository = new RegisteredPharmacyRepository(new MySQLStream<RegisteredPharmacy>(), new LongSequencer());



        }

        public static AppResources getInstance()
        {
            if (instance == null)
            {
                instance = new AppResources();
            }

            return instance;
        }

        public void LoadDoctorResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za doktora
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentDoctorStrategy();
        }

        public void LoadManagerResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za upravnika
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentManagerStrategy();
        }

        public void LoadPatientResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za pacijenta
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentPatientStrategy();
        }

        public void LoadSecretaryResources()
        {
            //TODO: Ovde se mogu ucitati strategy pattern i slicne specificne stvari za sekretara
            // Ucitava se prilikom login-a
            appointmentService.AppointmentStrategy = new AppointmentSecretaryStrategy();
            patientService.UserValidation = new SecretaryPatientValidation();
        }
    }
}
