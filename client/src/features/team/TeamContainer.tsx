import { Paper, Grid2 as Grid, Skeleton, Typography } from "@mui/material";

import { Request } from "../../app/models/request";
import TeamRequestList from "./TeamRequestList";

type Props = {
  requests: Request[];
};

export default function TeamContainer({ requests }: Props) {
  return (
    <Paper sx={{ p: 2, width: "100%" }} elevation={1}>
      <Grid container spacing={1}>
        <Grid size={5} />
        <Grid size={12}>
          <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
            Team Requests
          </Typography>
        </Grid>
        <Grid size={12}>
          <Skeleton height={14} />
        </Grid>
        <Grid size={5}>
          <TeamRequestList requests={requests} />
        </Grid>
        <Grid size={7}>
          <Paper>No Content</Paper>
        </Grid>
      </Grid>
    </Paper>
  );
}
