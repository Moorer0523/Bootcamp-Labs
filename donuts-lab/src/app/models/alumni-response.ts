import { Alumni } from "./alumni"
import { AlumniCondensed } from "./alumni-condensed"

export interface AlumniResponse {
    complete: Alumni[]
    tiny: AlumniCondensed[]
}
