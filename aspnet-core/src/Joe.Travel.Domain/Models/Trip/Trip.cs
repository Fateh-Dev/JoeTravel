using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Joe.Travel.Models
{
    public class Trip : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public double Rating { get; set; }

        public int Duration { get; set; }

        public byte[] Thumbnail { get; set; }

        public TripSize TripSize { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public bool IsAchived { get; set; }

        public Guid GuideId { get; set; }

        public ICollection<Image> Pictures { get; set; }

        public ICollection<TripActivity> Activities { get; set; }

        public ICollection<TripRisk> Risks { get; set; }

        public ICollection<TripIncludedStuff> IncludedStuffs { get; set; }

        public ICollection<TripLoging> Logings { get; set; }

        public ICollection<TripNotAllowedStuff> NotAllowedStuffs { get; set; }

        public ICollection<TripNotSuitableFor> NotSuitableFors { get; set; }

        public ICollection<TripRequiredStuff> RequiredStuffs { get; set; }

        private Trip()
        {
        }

        public Trip(
            Guid id,
            Guid guideId,
            string title,
            string description,
            Difficulty difficulty
        ) :
            base(id)
        {
            SetTitle (title);
            Description = description;
            Difficulty = difficulty;
            GuideId = guideId;
            Activities = new Collection<TripActivity>();
            Risks = new Collection<TripRisk>();
            IncludedStuffs = new Collection<TripIncludedStuff>();
            Logings = new Collection<TripLoging>();
            NotSuitableFors = new Collection<TripNotSuitableFor>();
            RequiredStuffs = new Collection<TripRequiredStuff>();
            NotAllowedStuffs = new Collection<TripNotAllowedStuff>();
        }

        public void SetTitle(string title)
        {
            // TODO Consts
            Title =
                Check
                    .NotNullOrWhiteSpace(title,
                    nameof(title),
                    TripConst.MaxTitleLength);
        }

        //********************************* Activities *********************************
        public void AddActivity(Guid activityId)
        {
            Check.NotNull(activityId, nameof(activityId));
            if (IsInActivities(activityId))
            {
                return;
            }
            Activities.Add(new TripActivity(tripId: Id, activityId));
        }

        public void RemoveActivity(Guid activityId)
        {
            Check.NotNull(activityId, nameof(activityId));
            if (!IsInActivities(activityId))
            {
                return;
            }
            Activities.RemoveAll(x => x.ActivityId == activityId);
        }

        public void RemoveAllActivitiesExceptGivenIds(List<Guid> activityIds)
        {
            Check.NotNullOrEmpty(activityIds, nameof(activityIds));
            Activities.RemoveAll(x => !activityIds.Contains(x.ActivityId));
        }

        public void RemoveAllActivities()
        {
            Activities.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInActivities(Guid activityId)
        {
            return Activities.Any(x => x.ActivityId == activityId);
        }

        //********************************* Risks *********************************
        public void AddRisks(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInRisks(riskId))
            {
                return;
            }
            Risks.Add(new TripRisk(tripId: Id, riskId));
        }

        public void RemoveRisk(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInRisks(riskId))
            {
                return;
            }
            Risks.RemoveAll(x => x.RiskId == riskId);
        }

        public void RemoveAllRisksExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            Risks.RemoveAll(x => !riskIds.Contains(x.RiskId));
        }

        public void RemoveAllRisks()
        {
            Risks.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInRisks(Guid riskId)
        {
            return Risks.Any(x => x.RiskId == riskId);
        }

        //********************************* Included Stuff *********************************
        public void AddIncludedStuffs(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInIncludedStuffs(riskId))
            {
                return;
            }
            IncludedStuffs.Add(new TripIncludedStuff(tripId: Id, riskId));
        }

        public void RemoveIncludedStuff(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInIncludedStuffs(riskId))
            {
                return;
            }
            IncludedStuffs.RemoveAll(x => x.IncludedStuffId == riskId);
        }

        public void RemoveAllIncludedStuffsExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            IncludedStuffs.RemoveAll(x => !riskIds.Contains(x.IncludedStuffId));
        }

        public void RemoveAllIncludedStuffs()
        {
            IncludedStuffs.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInIncludedStuffs(Guid riskId)
        {
            return IncludedStuffs.Any(x => x.IncludedStuffId == riskId);
        }

        //********************************* Loging *********************************
        public void AddLogings(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInLogings(riskId))
            {
                return;
            }
            Logings.Add(new TripLoging(tripId: Id, riskId));
        }

        public void RemoveLoging(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInLogings(riskId))
            {
                return;
            }
            Logings.RemoveAll(x => x.LogingId == riskId);
        }

        public void RemoveAllLogingsExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            Logings.RemoveAll(x => !riskIds.Contains(x.LogingId));
        }

        public void RemoveAllLogings()
        {
            Logings.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInLogings(Guid riskId)
        {
            return Logings.Any(x => x.LogingId == riskId);
        }

        //********************************* Not Allowed Stuff *********************************
        public void AddNotAllowedStuffs(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInNotAllowedStuffs(riskId))
            {
                return;
            }
            NotAllowedStuffs.Add(new TripNotAllowedStuff(tripId: Id, riskId));
        }

        public void RemoveNotAllowedStuff(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInNotAllowedStuffs(riskId))
            {
                return;
            }
            NotAllowedStuffs.RemoveAll(x => x.NotAllowedStuffId == riskId);
        }

        public void RemoveAllNotAllowedStuffsExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            NotAllowedStuffs
                .RemoveAll(x => !riskIds.Contains(x.NotAllowedStuffId));
        }

        public void RemoveAllNotAllowedStuffs()
        {
            NotAllowedStuffs.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInNotAllowedStuffs(Guid riskId)
        {
            return NotAllowedStuffs.Any(x => x.NotAllowedStuffId == riskId);
        }

        //********************************* Not Suitable For *********************************
        public void AddNotSuitableFors(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInNotSuitableFors(riskId))
            {
                return;
            }
            NotSuitableFors.Add(new TripNotSuitableFor(tripId: Id, riskId));
        }

        public void RemoveNotSuitableFor(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInNotSuitableFors(riskId))
            {
                return;
            }
            NotSuitableFors.RemoveAll(x => x.NotSuitableForId == riskId);
        }

        public void RemoveAllNotSuitableForsExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            NotSuitableFors
                .RemoveAll(x => !riskIds.Contains(x.NotSuitableForId));
        }

        public void RemoveAllNotSuitableFors()
        {
            NotSuitableFors.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInNotSuitableFors(Guid riskId)
        {
            return NotSuitableFors.Any(x => x.NotSuitableForId == riskId);
        }

        //********************************* Included Stuff *********************************
        public void AddRequiredStuffs(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (IsInRequiredStuffs(riskId))
            {
                return;
            }
            RequiredStuffs.Add(new TripRequiredStuff(tripId: Id, riskId));
        }

        public void RemoveRequiredStuff(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));
            if (!IsInRequiredStuffs(riskId))
            {
                return;
            }
            RequiredStuffs.RemoveAll(x => x.RequiredStuffId == riskId);
        }

        public void RemoveAllRequiredStuffsExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));
            RequiredStuffs.RemoveAll(x => !riskIds.Contains(x.RequiredStuffId));
        }

        public void RemoveAllRequiredStuffs()
        {
            RequiredStuffs.RemoveAll(x => x.TripId == Id);
        }

        private bool IsInRequiredStuffs(Guid riskId)
        {
            return RequiredStuffs.Any(x => x.RequiredStuffId == riskId);
        }
    }
}
