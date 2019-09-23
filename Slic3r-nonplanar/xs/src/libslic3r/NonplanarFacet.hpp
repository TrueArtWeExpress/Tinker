#ifndef slic3r_NonplanarFacet_hpp_
#define slic3r_NonplanarFacet_hpp_

#include "libslic3r.h"
#include "Geometry.hpp"

namespace Slic3r {

typedef struct {
  float x;
  float y;
  float z;
} facet_vertex;

typedef struct {
  facet_vertex    max;
  facet_vertex    min;
} facet_stats;

class NonplanarFacet
{
    public:
    facet_vertex vertex[3];
    facet_vertex normal;
    int neighbor[3];
    facet_stats stats;
    bool marked = false;

    NonplanarFacet() {};
    ~NonplanarFacet() {};
    void calculate_stats();
    void translate(float x, float y, float z);
    void scale(float versor[3]);
    float calculate_surface_area();

};
};

#endif
