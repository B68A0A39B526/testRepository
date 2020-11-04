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
        public LocationService locationService;
        public MessageService messageService;
        public NotificationService notificationService;
        public AppointmentNotificationSender appointmentNotificationSender;

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
            locationService = new LocationService(locationRepository);
            messageService = new MessageService(messageRepository);
            notificationService = new NotificationService(notificationRepository);
            appointmentNotificationSender = new AppointmentNotificationSender(notificationService);
            appointmentService = new AppointmentService(appointmentRepository, appointmentStrategy, appointmentNotificationSender);

            // UsersService
            doctorService = new DoctorService(doctorRepository, userRepository, appointmentService);
            managerService = new ManagerService(managerRepository);
            patientService = new PatientService(patientRepository, medicalRecordRepository);
            secretaryService = new SecretaryService(secretaryRepository);
            userService = new UserService(userRepository);

            appointmentRecommendationService = new AppointmentRecommendationService(appointmentService, doctorService);
        }

        private void LoadRepositories()
        {/*
            userRepository = new UserRepository(new MySQLStream<User>(), new LongSequencer());
            // USER OK


            roomRepository = new RoomRepository(new MySQLStream<Room>(), new LongSequencer());
            // ROOM OK

            inventoryItemRepository = new InventoryItemRepository(new MySQLStream<InventoryItem>(), new LongSequencer());

            timeTableRepository = new TimeTableRepository(new MySQLStream<TimeTable>(), new LongSequencer());
            // TIMETABLE OK
            */hospitalRepository = new HospitalRepository(new MySQLStream<Hospital>(), new LongSequencer());
            // HOSPITAL OK
            /*
            secretaryRepository = new SecretaryRepository(new MySQLStream<Secretary>(), new LongSequencer(), userRepository);
            // SECRETARY OK
            managerRepository = new ManagerRepository(new MySQLStream<Manager>(), new LongSequencer(), userRepository);
            // MANAGER OK
            doctorRepository = new DoctorRepository(new MySQLStream<Doctor>(), new LongSequencer(), userRepository);
            // DOCTOR OK
            patientRepository = new PatientRepository(new MySQLStream<Patient>(), new LongSequencer(), doctorRepository, userRepository);
            // PATIENT OK


            //Misc repositories
            locationRepository = new LocationRepository(new MySQLStream<Location>(), new LongSequencer());
            // LOCATION OK
            notificationRepository = new NotificationRepository(new MySQLStream<Notification>(), new LongSequencer());
            // NOTIFICATION OK
            messageRepository = new MessageRepository(new MySQLStream<Message>(), new LongSequencer());
            // MESSAGE OK
            articleRepository = new ArticleRepository(new MySQLStream<Article>(), new LongSequencer());
            //ARTICLE OK
            questionRepository = new QuestionRepository(new MySQLStream<Question>(), new LongSequencer());
            // QUESTION OK
            doctorQuestionRepository = new QuestionRepository(new MySQLStream<Question>(), new LongSequencer());
            //DOCTOR QUESTION OK
            feedbackRepository = new FeedbackRepository(new MySQLStream<Feedback>(), new LongSequencer());
            
            doctorFeedbackRepository = new DoctorFeedbackRepository(new MySQLStream<DoctorFeedback>(), new LongSequencer());


            //Hospital management repositories
            symptomRepository = new SymptomRepository(new MySQLStream<Symptom>(), new LongSequencer());
            //SYMPTOM REPO OK
            diseaseRepository = new DiseaseRepository(new MySQLStream<Disease>(), new LongSequencer(), medicineRepository, symptomRepository);
            //DISEASE REPO OK
            ingredientRepository = new IngredientRepository(new MySQLStream<Ingredient>(), new LongSequencer());
            //INGREDIENT REPO OK
            medicineRepository = new MedicineRepository(new MySQLStream<Medicine>(), new LongSequencer());
            //MEDICINE REPO OK


            prescriptionRepository = new PrescriptionRepository(new MySQLStream<Prescription>(), new LongSequencer());
            //PRESCRIPTION REPO OK

            //Medical repositories

            allergyRepository = new AllergyRepository(new MySQLStream<Allergy>(), new LongSequencer());
            //ALLERGY REPO OK

            appointmentRepository = new AppointmentRepository(new MySQLStream<Appointment>(), new LongSequencer());
            //GERGO REPO OK?
            therapyRepository = new TherapyRepository(new MySQLStream<Therapy>(), new LongSequencer());

            //med record
            medicalRecordRepository = new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new LongSequencer());
            //u medical record moras da set diagnosis repo
            diagnosisRepository = new DiagnosisRepository(new MySQLStream<Diagnosis>(), new LongSequencer());
            //therapy
            // therapyRepository = new TherapyRepository(new MySQLStream<Therapy>(therapyFile,new TherapyConverter()),new LongSequencer(),medicalRecordRepository, )

            //ODAVDDE RADITI OSTALE

            doctorStatisticRepository = new DoctorStatisticRepository(new MySQLStream<StatsDoctor>(), new LongSequencer());
            // Doc Stats OK

            inventoryStatisticRepository = new InventoryStatisticsRepository(new MySQLStream<StatsInventory>(), new LongSequencer());
            // InventoryStats OK

            roomStatisticRepository = new RoomStatisticsRepository(new MySQLStream<StatsRoom>(), new LongSequencer());
            // RoomStats OK

            inventoryRepository = new InventoryRepository(new MySQLStream<Inventory>(), new LongSequencer());
            */
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
