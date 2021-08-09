# v1.4.3 (Mon. Aug 9th, 2021)

#### Bugfix

 - Addressing issue #26: Fixing broken serialization of `ProjectReportTotals`.

# v1.4.2 (Fri. Aug 6th, 2021)

#### Bugfix

 - Addressing issue #24: Fixing broken serialization of `ProjectReport`.

# v1.4.1 (Wed. Jul 14th, 2021)

#### THIS IS A BREAKING CHANGE RELEASE
 - Addressing issue #22: All entity and entity reference ID's are now data type _long_.

# v1.4.0 (Wed. Jan 13, 2021)

#### Feature

- Added `connectWithQuickBooks` property to `Jobcode` to support the two-way sync feature.

# v1.3.2 (Tues. Jun. 9th, 2020)

#### Bugfix

 - Adding missing GeofenceConfigyType enumeration value for 'locations'

# v1.3.1 (Thurs. Mar. 19th, 2020)

#### Bugfix

 - Fixing issue #17: Unhandled exception on GetDateTimeOffsetValue

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