using App_Domain.Concretes;
using App_Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.ConfigurationMapping
{
    public class ConfigTopic : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("integer");


            builder.Property(x => x.TopicName)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.SubTopicName)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("nvarchar(10)");

            builder.Property(x => x.CreateDate)
                .IsRequired(true)
                .HasColumnType("date");

            builder.Property(x => x.DropDate)
                .IsRequired(false)
                .HasColumnType("date");

            //Data Seed

            builder.HasData
                (
                //------------------------------------------------------------------------------------------------------------------------------ 
                //WORK

                new Topic { Id = 1, TopicName = "Work", SubTopicName = "Business", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 2, TopicName = "Work", SubTopicName = "Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 3, TopicName = "Work", SubTopicName = "Leadership", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 4, TopicName = "Work", SubTopicName = "Remote Work", CreateDate = DateTime.Now, Status = Status.Created },
                //****************************

                    //Work => Business
                    new Topic { Id = 5, TopicName = "Business", SubTopicName = "Entrepreneurship", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 6, TopicName = "Business", SubTopicName = "Freelancing", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 7, TopicName = "Business", SubTopicName = "Small Business", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 8, TopicName = "Business", SubTopicName = "Startups", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 9, TopicName = "Business", SubTopicName = "Venture Capital", CreateDate = DateTime.Now, Status = Status.Created },

                        //Work => Business => ...
                        new Topic { Id = 1000, TopicName = "Entrepreneurship", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1001, TopicName = "Freelancing", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1002, TopicName = "Small Business", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1003, TopicName = "Startups", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1004, TopicName = "Venture Capital", CreateDate = DateTime.Now, Status = Status.Created },

                    //Work => Marketing
                    new Topic { Id = 10, TopicName = "Marketing", SubTopicName = "Advertising", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 11, TopicName = "Marketing", SubTopicName = "Branding", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 12, TopicName = "Marketing", SubTopicName = "Content Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 13, TopicName = "Marketing", SubTopicName = "Content Strategy", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 14, TopicName = "Marketing", SubTopicName = "Digital Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 15, TopicName = "Marketing", SubTopicName = "SEO", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 16, TopicName = "Marketing", SubTopicName = "Social Media Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 17, TopicName = "Marketing", SubTopicName = "Storytelling For Business", CreateDate = DateTime.Now, Status = Status.Created },

                        //Work => Marketing =>...
                        new Topic { Id = 1005, TopicName = "Advertising", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1006, TopicName = "Branding", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1007, TopicName = "Content Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1008, TopicName = "Content Strategy", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1009, TopicName = "Digital Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1010, TopicName = "SEO", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1011, TopicName = "Social Media Marketing", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1012, TopicName = "Storytelling For Business", CreateDate = DateTime.Now, Status = Status.Created },




                    //Work => LeaderShip
                    new Topic { Id = 18, TopicName = "Leadership", SubTopicName = "Employee Engagement", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 19, TopicName = "Leadership", SubTopicName = "Leadership Coaching", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 20, TopicName = "Leadership", SubTopicName = "Leadership Development", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 21, TopicName = "Leadership", SubTopicName = "Management", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 22, TopicName = "Leadership", SubTopicName = "Meetings", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 23, TopicName = "Leadership", SubTopicName = "Org Charts", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 24, TopicName = "Leadership", SubTopicName = "Thought Leadership", CreateDate = DateTime.Now, Status = Status.Created },

                        //Work => LeaderShip =>...
                        new Topic { Id = 1013, TopicName = "Employee Engagement", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1014, TopicName = "Leadership Coaching", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1015, TopicName = "Leadership Development", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1016, TopicName = "Management", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1017, TopicName = "Meetings", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1018, TopicName = "Org Charts", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1019, TopicName = "Thought Leadership", CreateDate = DateTime.Now, Status = Status.Created },


                    //Work => RemoteWork
                    new Topic { Id = 25, TopicName = "Remote Work", SubTopicName = "Company Retreats", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 26, TopicName = "Remote Work", SubTopicName = "Digital Nomads", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 27, TopicName = "Remote Work", SubTopicName = "Distributed Teams", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 28, TopicName = "Remote Work", SubTopicName = "Future Of Work", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 29, TopicName = "Remote Work", SubTopicName = "Work From Home", CreateDate = DateTime.Now, Status = Status.Created },

                        //Work => RemoteWork =>...
                        new Topic { Id = 1020, TopicName = "Company Retreats", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1021, TopicName = "Digital Nomads", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1022, TopicName = "Distributed Teams", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1023, TopicName = "Future Of Work", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1024, TopicName = "Work From Home", CreateDate = DateTime.Now, Status = Status.Created },



                //------------------------------------------------------------------------------------------------------------------------------

                //LIFE
                new Topic { Id = 30, TopicName = "Life", SubTopicName = "Family", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 31, TopicName = "Life", SubTopicName = "Health", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 32, TopicName = "Life", SubTopicName = "Relationships", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 33, TopicName = "Life", SubTopicName = "Sexuality", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 34, TopicName = "Life", SubTopicName = "Home", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 35, TopicName = "Life", SubTopicName = "Food", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 36, TopicName = "Life", SubTopicName = "Pets", CreateDate = DateTime.Now, Status = Status.Created },
                //*************************


                    //Life => Family
                    new Topic { Id = 37, TopicName = "Family", SubTopicName = "Adoption", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 38, TopicName = "Family", SubTopicName = "Children", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 39, TopicName = "Family", SubTopicName = "Elder Care", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 40, TopicName = "Family", SubTopicName = "Fatherhood", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 41, TopicName = "Family", SubTopicName = "Motherhood", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 42, TopicName = "Family", SubTopicName = "Parenting", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 43, TopicName = "Family", SubTopicName = "Pregnancy", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 44, TopicName = "Family", SubTopicName = "Seniors", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Family =>...
                        new Topic { Id = 1025, TopicName = "Family", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1026, TopicName = "Health", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1027, TopicName = "Relationships", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1028, TopicName = "Sexuality", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1029, TopicName = "Home", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1030, TopicName = "Food", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1031, TopicName = "Pets", CreateDate = DateTime.Now, Status = Status.Created },


                    //Life => Health
                    new Topic { Id = 45, TopicName = "Health", SubTopicName = "Aging", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 46, TopicName = "Health", SubTopicName = "Coronavirus", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 47, TopicName = "Health", SubTopicName = "Covid-19", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 48, TopicName = "Health", SubTopicName = "Death And Dying", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 49, TopicName = "Health", SubTopicName = "Disease", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 50, TopicName = "Health", SubTopicName = "Fitness", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 51, TopicName = "Health", SubTopicName = "Mens Health", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 52, TopicName = "Health", SubTopicName = "Nutrition", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 53, TopicName = "Health", SubTopicName = "Sleep", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 54, TopicName = "Health", SubTopicName = "Trans Healthcare", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 55, TopicName = "Health", SubTopicName = "Vaccines", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 56, TopicName = "Health", SubTopicName = "Weight Loss", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 57, TopicName = "Health", SubTopicName = "Womens Health", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Health =>...
                        new Topic { Id = 1040, TopicName = "Aging", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1041, TopicName = "Coronavirus", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1042, TopicName = "Covid-19", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1043, TopicName = "Death And Dying", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1044, TopicName = "Disease", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1045, TopicName = "Fitness", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1046, TopicName = "Mens Health", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1047, TopicName = "Nutrition", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1048, TopicName = "Sleep", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1049, TopicName = "Trans Healthcare", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1050, TopicName = "Vaccines", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1051, TopicName = "Weight Loss", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1052, TopicName = "Womens Health", CreateDate = DateTime.Now, Status = Status.Created },


                    //Life =>RelationShip
                    new Topic { Id = 58, TopicName = "Relationships", SubTopicName = "Dating", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 59, TopicName = "Relationships", SubTopicName = "Divorce", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 60, TopicName = "Relationships", SubTopicName = "Friendship", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 61, TopicName = "Relationships", SubTopicName = "Love", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 62, TopicName = "Relationships", SubTopicName = "Marriage", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 63, TopicName = "Relationships", SubTopicName = "Polyamory", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => RelationShip =>...
                        new Topic { Id = 1053, TopicName = "Dating", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1054, TopicName = "Divorce", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1055, TopicName = "Friendship", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1056, TopicName = "Love", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1057, TopicName = "Marriage", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1058, TopicName = "Polyamory", CreateDate = DateTime.Now, Status = Status.Created },



                    //Life => Sexuality
                    new Topic { Id = 64, TopicName = "Sexuality", SubTopicName = "BDSM", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 65, TopicName = "Sexuality", SubTopicName = "Erotica", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 66, TopicName = "Sexuality", SubTopicName = "Kink", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 67, TopicName = "Sexuality", SubTopicName = "Sex", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 68, TopicName = "Sexuality", SubTopicName = "Sexual Health", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Sexuality =>...
                        new Topic { Id = 1059, TopicName = "BDSM", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1060, TopicName = "Erotica", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1061, TopicName = "Kink", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1062, TopicName = "Sex", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1063, TopicName = "Sexual Health", CreateDate = DateTime.Now, Status = Status.Created },



                    //Life => Home
                    new Topic { Id = 69, TopicName = "Home", SubTopicName = "Architecture", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 70, TopicName = "Home", SubTopicName = "Home Improvement", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 71, TopicName = "Home", SubTopicName = "Homeownership", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 72, TopicName = "Home", SubTopicName = "Interior Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 73, TopicName = "Home", SubTopicName = "Rental Property", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 74, TopicName = "Home", SubTopicName = "Vacation Rental", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Home =>...
                        new Topic { Id = 1064, TopicName = "Architecture", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1065, TopicName = "Home Improvement", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1066, TopicName = "Homeownership", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1067, TopicName = "Interior Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1068, TopicName = "Rental Property", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1069, TopicName = "Vacation Rental", CreateDate = DateTime.Now, Status = Status.Created },


                    //Life => Food
                    new Topic { Id = 75, TopicName = "Food", SubTopicName = "Baking", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 76, TopicName = "Food", SubTopicName = "Coffee", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 77, TopicName = "Food", SubTopicName = "Cooking", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 78, TopicName = "Food", SubTopicName = "Foodies", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 79, TopicName = "Food", SubTopicName = "Restaurants", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 80, TopicName = "Food", SubTopicName = "Tea", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Food =>...
                        new Topic { Id = 1070, TopicName = "Baking", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1071, TopicName = "Coffee", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1072, TopicName = "Cooking", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1073, TopicName = "Foodies", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1074, TopicName = "Restaurants", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1075, TopicName = "Tea", CreateDate = DateTime.Now, Status = Status.Created },


                    //Life => Pets
                    new Topic { Id = 81, TopicName = "Pets", SubTopicName = "Cats", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 82, TopicName = "Pets", SubTopicName = "Dog Training", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 83, TopicName = "Pets", SubTopicName = "Dogs", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 84, TopicName = "Pets", SubTopicName = "Hamsters", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 85, TopicName = "Pets", SubTopicName = "Horses", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 86, TopicName = "Pets", SubTopicName = "Pet Care", CreateDate = DateTime.Now, Status = Status.Created },

                        //Life => Pets =>...
                        new Topic { Id = 1076, TopicName = "Cats", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1077, TopicName = "Dog Training", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1078, TopicName = "Dogs", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1079, TopicName = "Hamsters", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1080, TopicName = "Horses", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1081, TopicName = "Pet Care", CreateDate = DateTime.Now, Status = Status.Created },

                //------------------------------------------------------------------------------------------------------------------------------

                //TECHNOLOGY
                new Topic { Id = 88, TopicName = "Technology", SubTopicName = "Artificial Intelligence", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 89, TopicName = "Technology", SubTopicName = "Blockchain", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 90, TopicName = "Technology", SubTopicName = "Data Science", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 91, TopicName = "Technology", SubTopicName = "Gadgets", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 92, TopicName = "Technology", SubTopicName = "Makers", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 93, TopicName = "Technology", SubTopicName = "Security", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 94, TopicName = "Technology", SubTopicName = "Tech Companies", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 95, TopicName = "Technology", SubTopicName = "Design", CreateDate = DateTime.Now, Status = Status.Created },
                new Topic { Id = 96, TopicName = "Technology", SubTopicName = "Product Management", CreateDate = DateTime.Now, Status = Status.Created },
                //***********************


                    //Technology => AI
                    new Topic { Id = 97, TopicName = "Artificial Intelligence", SubTopicName = "ChatGPT", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 98, TopicName = "Artificial Intelligence", SubTopicName = "Conversational AI", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 99, TopicName = "Artificial Intelligence", SubTopicName = "Deep Learning", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 100, TopicName = "Artificial Intelligence", SubTopicName = "Large Language Models", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 101, TopicName = "Artificial Intelligence", SubTopicName = "Machine Learning", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 102, TopicName = "Artificial Intelligence", SubTopicName = "NLP", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 103, TopicName = "Artificial Intelligence", SubTopicName = "Voice Assistant", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => AI =>...
                        new Topic { Id = 1082, TopicName = "ChatGPT", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1083, TopicName = "Conversational AI", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1084, TopicName = "Deep Learning", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1085, TopicName = "Large Language Models", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1086, TopicName = "Machine Learning", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1087, TopicName = "NLP", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1088, TopicName = "Voice Assistant", CreateDate = DateTime.Now, Status = Status.Created },

                    //Technology => Blockchain
                    new Topic { Id = 104, TopicName = "Blockchain", SubTopicName = "Bitcoin", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 105, TopicName = "Blockchain", SubTopicName = "Cryptocurrency", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 106, TopicName = "Blockchain", SubTopicName = "Decentralized Finance", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 107, TopicName = "Blockchain", SubTopicName = "Ethereum", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 108, TopicName = "Blockchain", SubTopicName = "NFT", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 109, TopicName = "Blockchain", SubTopicName = "Web3", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Blockchain =>...
                        new Topic { Id = 1089, TopicName = "Bitcoin", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1090, TopicName = "Cryptocurrency", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1091, TopicName = "Decentralized Finance", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1092, TopicName = "Ethereum", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1093, TopicName = "NFT", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1094, TopicName = "Web3", CreateDate = DateTime.Now, Status = Status.Created },


                    //Technology => Data Science
                    new Topic { Id = 110, TopicName = "Data Science", SubTopicName = "Analytics", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 111, TopicName = "Data Science", SubTopicName = "Data Engineering", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 112, TopicName = "Data Science", SubTopicName = "Data Visualization", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 113, TopicName = "Data Science", SubTopicName = "Database Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 114, TopicName = "Data Science", SubTopicName = "SQL", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Data Science =>...
                        new Topic { Id = 1095, TopicName = "Analytics", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1096, TopicName = "Data Engineering", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1097, TopicName = "Data Visualization", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1098, TopicName = "Database Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1099, TopicName = "SQL", CreateDate = DateTime.Now, Status = Status.Created },


                    //Technology => Gadgets
                    new Topic { Id = 115, TopicName = "Gadgets", SubTopicName = "eBook", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 116, TopicName = "Gadgets", SubTopicName = "Internet of Things", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 117, TopicName = "Gadgets", SubTopicName = "iPad", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 118, TopicName = "Gadgets", SubTopicName = "Smart Home", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 119, TopicName = "Gadgets", SubTopicName = "Smartphones", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 120, TopicName = "Gadgets", SubTopicName = "Wearables", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Gadgets =>...
                        new Topic { Id = 1100, TopicName = "eBook", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1101, TopicName = "Internet of Things", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1102, TopicName = "iPad", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1103, TopicName = "Smart Home", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1104, TopicName = "Smartphones", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1105, TopicName = "Wearables", CreateDate = DateTime.Now, Status = Status.Created },

                    //Technology => Makers
                    new Topic { Id = 121, TopicName = "Makers", SubTopicName = "3D Printing", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 122, TopicName = "Makers", SubTopicName = "Arduino", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 123, TopicName = "Makers", SubTopicName = "DIY", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 124, TopicName = "Makers", SubTopicName = "Raspberry Pi", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 125, TopicName = "Makers", SubTopicName = "Robotics", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Makers =>...
                        new Topic { Id = 1106, TopicName = "3D Printing", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1107, TopicName = "Arduino", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1108, TopicName = "DIY", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1109, TopicName = "Raspberry Pi", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1110, TopicName = "Robotics", CreateDate = DateTime.Now, Status = Status.Created },

                    //Technology => Security
                    new Topic { Id = 126, TopicName = "Security", SubTopicName = "Cybersecurity", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 127, TopicName = "Security", SubTopicName = "Data Security", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 128, TopicName = "Security", SubTopicName = "Encryption", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 129, TopicName = "Security", SubTopicName = "Infosec", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 130, TopicName = "Security", SubTopicName = "Passwords", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 131, TopicName = "Security", SubTopicName = "Privacy", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Security =>...
                        new Topic { Id = 1111, TopicName = "Cybersecurity", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1112, TopicName = "Data Security", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1113, TopicName = "Encryption", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1114, TopicName = "Infosec", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1115, TopicName = "Passwords", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1116, TopicName = "Privacy", CreateDate = DateTime.Now, Status = Status.Created },

                    //Technology => Design
                    new Topic { Id = 132, TopicName = "Design", SubTopicName = "Accessibility", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 133, TopicName = "Design", SubTopicName = "Design Systems", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 134, TopicName = "Design", SubTopicName = "Design Thinking", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 135, TopicName = "Design", SubTopicName = "Graphic Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 136, TopicName = "Design", SubTopicName = "Icon Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 137, TopicName = "Design", SubTopicName = "Inclusive Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 138, TopicName = "Design", SubTopicName = "Product Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 139, TopicName = "Design", SubTopicName = "Typography", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 140, TopicName = "Design", SubTopicName = "UX Design", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 141, TopicName = "Design", SubTopicName = "UX Research", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Design =>...
                        new Topic { Id = 1117, TopicName = "Accessibility", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1118, TopicName = "Design Systems", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1119, TopicName = "Design Thinking", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1120, TopicName = "Graphic Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1121, TopicName = "Icon Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1122, TopicName = "Inclusive Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1123, TopicName = "Product Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1124, TopicName = "Typography", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1125, TopicName = "UX Design", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1126, TopicName = "UX Research", CreateDate = DateTime.Now, Status = Status.Created },

                    //Technology => Product Management
                    new Topic { Id = 142, TopicName = "Product Management", SubTopicName = "Agile", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 143, TopicName = "Product Management", SubTopicName = "Innovation", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 144, TopicName = "Product Management", SubTopicName = "Kanban", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 145, TopicName = "Product Management", SubTopicName = "Lean Startup", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 146, TopicName = "Product Management", SubTopicName = "MVP", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 147, TopicName = "Product Management", SubTopicName = "Product", CreateDate = DateTime.Now, Status = Status.Created },
                    new Topic { Id = 148, TopicName = "Product Management", SubTopicName = "Strategy", CreateDate = DateTime.Now, Status = Status.Created },

                        //Technology => Product Management =>...
                        new Topic { Id = 1127, TopicName = "Agile", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1128, TopicName = "Innovation", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1129, TopicName = "Kanban", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1130, TopicName = "Lean Startup", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1131, TopicName = "MVP", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1132, TopicName = "Product", CreateDate = DateTime.Now, Status = Status.Created },
                        new Topic { Id = 1133, TopicName = "Strategy", CreateDate = DateTime.Now, Status = Status.Created }


                );

        }
    }
}
