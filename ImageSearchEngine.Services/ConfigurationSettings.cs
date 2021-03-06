﻿using System;
using System.Collections.Generic;
using System.Linq;
using ImageSearchEngine.DTO;
using ImageSearchEngine.DTO.Enum;

namespace ImageSearchEngine.Services
{
    public class ConfigurationSettings
    {
        public static List<DescriptorMetadata> GetDocumentDescriptorsPerDb(string dbName)
        {
            var lstReturnedDescriptors = GetDbConfigurations()
                                            .Single(x => x.Code == dbName)
                                            .DescriptorsCodes;

            return lstReturnedDescriptors;
        }

        public static List<ImageMetric> GetImageMetricsPerDb(string descriptorName)
        {
            var lstReturnedMetrics = new List<ImageMetric>();
            lstReturnedMetrics.Add(new ImageMetric()
            {
                Id = Convert.ToInt32(MetricTypeEnum.Euclidian),
                Name = "Euclidian"
            });
            lstReturnedMetrics.Add(new ImageMetric()
            {
                Id = Convert.ToInt32(MetricTypeEnum.Manhattan),
                Name = "Manhattan"
            });
            lstReturnedMetrics.Add(new ImageMetric()
            {
                Id = Convert.ToInt32(MetricTypeEnum.Cosinus),
                Name = "Cosinus"
            });

            return lstReturnedMetrics;
        }

        private static List<DocumentDatabase> GetDbConfigurations()
        {
            var lstDatabases = new List<DocumentDatabase>();

            DocumentDatabase db = new DocumentDatabase() { Id = 1, Code = "medicalDb", Folder = "db", Name = "Cancer database", Icon = "glyphicon glyphicon-plus" };
            db.DescriptorsCodes.Add(new DescriptorMetadata() { Id = "CSD", Name = "Color Structure Descriptor"});
            db.DescriptorsCodes.Add(new DescriptorMetadata() { Id = "CLD", Name = "Color Layout Descriptor" });
            lstDatabases.Add(db);

            return lstDatabases;
        }

        public static List<DocumentDatabase> GetDatabasesList()
        {
            return GetDbConfigurations();
        }

    }
}
