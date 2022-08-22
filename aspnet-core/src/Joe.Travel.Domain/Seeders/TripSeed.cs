using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Joe.Travel.Models;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Joe.Travel
{
    public class
    TripStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Trip, Guid> _tripRepository;

        private readonly IRepository<Activity, Guid> _activityRepository;

        private readonly IRepository<Risk, Guid> _riskRepository;

        private readonly IRepository<NotAllowedStuff, Guid>
            _notAllowedStuffRepository;

        private readonly IRepository<NotSuitableFor, Guid>
            _notSuitableForRepository;

        private readonly IRepository<Loging, Guid> _logingRepository;

        private readonly IRepository<IncludedStuff, Guid>
            _includedStuffRepository;

        private readonly IRepository<RequiredStuff, Guid>
            _requiredStuffRepository;

        private readonly IRepository<Guide, Guid> _guideRepository;

        private readonly IGuidGenerator _guidGenerator;

        public TripStoreDataSeederContributor(
            IGuidGenerator guidGenerator,
            IRepository<Trip, Guid> tripRepository,
            IRepository<Activity, Guid> activityRepository,
            IRepository<Risk, Guid> riskRepository,
            IRepository<NotAllowedStuff, Guid> notAllowedStuffRepository,
            IRepository<NotSuitableFor, Guid> notSuitableForkRepository,
            IRepository<Loging, Guid> logingepository,
            IRepository<IncludedStuff, Guid> includedStuffRepository,
            IRepository<RequiredStuff, Guid> requiredStuffRepository,
            IRepository<Guide, Guid> guideRepository
        )
        {
            _guidGenerator = guidGenerator;
            _tripRepository = tripRepository;
            _activityRepository = activityRepository;
            _riskRepository = riskRepository;
            _notAllowedStuffRepository = notAllowedStuffRepository;
            _notSuitableForRepository = notSuitableForkRepository;
            _logingRepository = logingepository;
            _requiredStuffRepository = requiredStuffRepository;
            _includedStuffRepository = includedStuffRepository;
            _guideRepository = guideRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await SeedActivities();
            await SeedGuides();
            await SeedRisks();
            await SeedNotAllowedStuff();
            await SeedTrips();
            await SeedIncluds();
            await SeedLogings();
            await SeedRequirements();
            await SeedNotSuitables();
        }

        public async Task SeedActivities()
        {
            if (await _activityRepository.GetCountAsync() <= 0)
            {
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Skiing",
                        "-"));
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Backpacking",
                        "-"));
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Hiking",
                        "-"));
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Swimming",
                        "-"));
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Cycling",
                        "-"));
                await _activityRepository
                    .InsertAsync(new Activity(_guidGenerator.Create(),
                        "Walking",
                        "-"));
            }
        }

        public async Task SeedNotAllowedStuff()
        {
            if (await _notAllowedStuffRepository.GetCountAsync() <= 0)
            {
                await _notAllowedStuffRepository
                    .InsertAsync(new NotAllowedStuff(_guidGenerator.Create(),
                        "Weapons",
                        "-"));
                await _notAllowedStuffRepository
                    .InsertAsync(new NotAllowedStuff(_guidGenerator.Create(),
                        "Smoking",
                        "-"));
                await _notAllowedStuffRepository
                    .InsertAsync(new NotAllowedStuff(_guidGenerator.Create(),
                        "Drogs",
                        "-"));
                await _notAllowedStuffRepository
                    .InsertAsync(new NotAllowedStuff(_guidGenerator.Create(),
                        "Knives",
                        "-"));
                await _notAllowedStuffRepository
                    .InsertAsync(new NotAllowedStuff(_guidGenerator.Create(),
                        "Alcohol",
                        "-"));
            }
        }

        // TODO Complete Other Tables Seed
        public async Task SeedRisks()
        {
            if (await _riskRepository.GetCountAsync() <= 0)
            {
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 1",
                        "-"));
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 2",
                        "-"));
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 3",
                        "-"));
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 4",
                        "-"));
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 5",
                        "-"));
                await _riskRepository
                    .InsertAsync(new Risk(_guidGenerator.Create(),
                        "Risk 6",
                        "-"));
            }
        }

        public async Task SeedLogings()
        {
            if (await _logingRepository.GetCountAsync() <= 0)
            {
                await _logingRepository
                    .InsertAsync(new Loging(_guidGenerator.Create(),
                        "Hotel",
                        "-"));
                await _logingRepository
                    .InsertAsync(new Loging(_guidGenerator.Create(),
                        "Model",
                        "-"));
                await _logingRepository
                    .InsertAsync(new Loging(_guidGenerator.Create(),
                        "tent",
                        "-"));
                await _logingRepository
                    .InsertAsync(new Loging(_guidGenerator.Create(),
                        "Van",
                        "-"));
                await _logingRepository
                    .InsertAsync(new Loging(_guidGenerator.Create(),
                        "Hostel",
                        "-"));
            }
        }

        public async Task SeedNotSuitables()
        {
            if (await _notSuitableForRepository.GetCountAsync() <= 0)
            {
                await _notSuitableForRepository
                    .InsertAsync(new NotSuitableFor(_guidGenerator.Create(),
                        "Wheelchair users",
                        "-"));
                await _notSuitableForRepository
                    .InsertAsync(new NotSuitableFor(_guidGenerator.Create(),
                        "Pregnant Women",
                        "-"));
                await _notSuitableForRepository
                    .InsertAsync(new NotSuitableFor(_guidGenerator.Create(),
                        "kids",
                        "-"));
            }
        }

        public async Task SeedRequirements()
        {
            if (await _requiredStuffRepository.GetCountAsync() <= 0)
            {
                await _requiredStuffRepository
                    .InsertAsync(new RequiredStuff(_guidGenerator.Create(),
                        "Comfortable shoes",
                        "-"));
                await _requiredStuffRepository
                    .InsertAsync(new RequiredStuff(_guidGenerator.Create(),
                        "Jacket",
                        "-"));
            }
        }

        public async Task SeedIncluds()
        {
            if (await _includedStuffRepository.GetCountAsync() <= 0)
            {
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Roundtrip transportation by air-conditioned bus",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Skip-the-line ticket to Pompeii",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Tour guide",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Entry ticket to Vesuvius National Park (April-mid-November)",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Hotel pickup and drop-off",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "Food and drinks",
                        "-"));
                await _includedStuffRepository
                    .InsertAsync(new IncludedStuff(_guidGenerator.Create(),
                        "English-speaking tour guide for the day",
                        "-"));
            }
        }

        // Not Suitable For
        // Required Stuff
        public async Task SeedGuides()
        {
            if (await _guideRepository.GetCountAsync() <= 0)
            {
                await _guideRepository
                    .InsertAsync(new Guide(Guid
                            .Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                        "Amine",
                        "Aiche"));
                await _guideRepository
                    .InsertAsync(new Guide(_guidGenerator.Create(),
                        "Fateh",
                        "Djehinet"));
                await _guideRepository
                    .InsertAsync(new Guide(_guidGenerator.Create(),
                        "Abdelkader",
                        "Khellouf"));
            }
        }

        public async Task SeedTrips()
        {
            if (await _tripRepository.GetCountAsync() <= 0)
            {
                await _tripRepository
                    .InsertAsync(new Trip(_guidGenerator.Create(),
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                        "Rome : visite avec arène, Forum Romain et mont Palatin",
                        "Participez à une visite guidée de trois icônes de la Rome antique : le Colisée, le Forum romain et le Palatin, et laissez votre guide faire revivre l'histoire.",
                        Difficulty.Easy) {
                        Duration = 9,
                        DurationUnit = DurationUnit.Hour,
                        TripSize = TripSize.Medium
                    });

                await _tripRepository
                    .InsertAsync(new Trip(_guidGenerator.Create(),
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                        "Las Vegas : Antelope Canyon, Horseshoe Bend, prise en charge",
                        "Découvrez le célèbre Lower Antelope Canyon ou le reculé Antelope Canyon X lors de ce circuit en petit groupe avec transferts et guide Navajo.",
                        Difficulty.Easy)
                    {
                        Duration = 3,
                        DurationUnit = DurationUnit.Day,
                        TripSize = TripSize.Small
                    });

                await _tripRepository
                    .InsertAsync(new Trip(_guidGenerator.Create(),
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                        "Depuis Hurghada : journée dans la vallée des rois de Louxor",
                        "Visitez les monuments de Louxor en réservant cette excursion d'une journée. Découvrez la capitale des pharaons et son impressionnant héritage architectural : le temple de Karnak, la vallée des Rois, les colosses de Memnon et le temple d'Hatchepsout.",
                        Difficulty.Easy) {
                        Duration = 6,
                        DurationUnit = DurationUnit.Day,
                        TripSize = TripSize.Medium
                    });
            }
        }
    }
}
