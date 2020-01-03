# v1.3.0 (Fri. Jan 3rd, 2020)

#### Feature

 - Added Create and Update operations for Custom Field objects.
 - Updated User model to include new DisplayName & Pronoun properties.

# v1.2.1 (Mon. Nov 11th, 2019)

#### Bugfix

 - Fixing issue #13: Error with DateTimeOffset in ScheduleEvent object.

# v1.2.0 (Mon. Oct 21st, 2019)

#### Minor Feature

- Adding CancellationToken support for all asynchronous API methods.
- Adding support for geofence_config object in supplemental data.

# v1.1.2 (Tue. Sep 24th, 2019)

#### Bugfix

- Fixing issue #7: PackageLicenseUrl error (NuGet NU5035), causing a failure to build on VS2019.

# v1.1.1 (Mon. Sep 16th, 2019)

#### Minor Bugfix

- Enabling non-breaking introduction of new supplemental data sections in EntityTypeMapper.

# v1.1.0 (Thu. Sep 12th, 2019)

#### Minor Feature Update

- Adding `Name` property to `JobcodeFilter`, for looking up jobcodes by wildcardable name.

# v1.0.2 (Fri. Sep 6th, 2019)

#### Genesis

- initial drop