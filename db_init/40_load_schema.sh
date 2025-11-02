#!/bin/bash
set -e
sqlplus -s appuser/"AppPass#2025"@localhost:1521/FREEPDB1 @/opt/oracle/scripts/startup/challenge_oracle2_fixed.sql
