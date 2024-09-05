

DOMAIN:
		classes:
			
			User:
				Props:
					Username;
					Email;
					Password;
					FirstName;
					LastName;
				Nav Props:
					Virtual ICollection<Story> Stories
				
			Story:
				Props:
					Title;
					Content;
				Nav Props:
					UserId;
					User User;
					VirtualCollection<StoryTopic> StoryTopics


			Topics:
				Props:
					ParentTopicName;
					TopicName;
					SubTopicName;
				
				Nav Props:
					VirtualCollection<StoryTopic> StoryTopics

			StoryTopic:
				Nav Props:
					TopicId;
					Topic Topic
					StoryId
					Story Story