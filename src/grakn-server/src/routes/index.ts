import { Router } from 'express';
import GraknRouter from './grakn';
// Init router and path
const router = Router();
// Add sub-routes
router.use('/grakn', GraknRouter);

// Export the base-router
export default router;
