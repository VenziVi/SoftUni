namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        private Dictionary<int, Member> membersById;
        private Dictionary<int, Trainer> trainersById;

        public FitGym()
        {
            this.membersById = new Dictionary<int, Member>();
            this.trainersById = new Dictionary<int, Trainer>();
        }
        public void AddMember(Member member)
        {
            if (this.membersById.ContainsKey(member.Id))
                throw new ArgumentException();

            this.membersById.Add(member.Id, member);
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.trainersById.ContainsKey(trainer.Id))
                throw new ArgumentException();

            this.trainersById.Add(trainer.Id, trainer);
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.membersById.ContainsKey(member.Id))
                this.membersById.Add(member.Id, member);

            if (member.Trainer != null ||
                !this.trainersById.ContainsKey(trainer.Id))
                throw new ArgumentException();


            member.Trainer = trainer;
            trainer.Members.Add(member);
        }

        public bool Contains(Member member)
        {
            return this.membersById.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return this.trainersById.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.trainersById.ContainsKey(id))
                throw new ArgumentException();

            var trainer = this.trainersById[id];
            this.trainersById.Remove(id);
            return trainer;
        }

        public Member RemoveMember(int id)
        {
            if (!this.membersById.ContainsKey(id))
                throw new ArgumentException();

            var member = this.membersById[id];
            this.membersById.Remove(id);
            return member;
        }

        public int MemberCount { get { return this.membersById.Count; } }
        public int TrainerCount { get { return this.trainersById.Count; } }

        public IEnumerable<Member> 
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            return this.membersById.Values.OrderBy(m => m.RegistrationDate).ThenByDescending(m => m.Name);
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            return this.trainersById.Values.OrderBy(t => t.Popularity);
        }

        public IEnumerable<Member> 
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            return trainer.Members.OrderBy(m => m.RegistrationDate).ThenBy(m => m.Name);
        }

        public IEnumerable<Member> 
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            return this.membersById
                .Values
                .Where(m => m.Trainer.Popularity >= lo && m.Trainer.Popularity <= hi)
                .OrderBy(m => m.Visits);
        }

        public Dictionary<Trainer, HashSet<Member>> 
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            return this.trainersById
                .OrderBy(t => t.Value.Members.Count)
                .OrderBy(t => t.Value.Popularity)
                .ToDictionary(k => k.Value, v => v.Value.Members);
        }
    }
}